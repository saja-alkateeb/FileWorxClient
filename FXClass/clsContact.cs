using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorxServer
{
    public class clsContact : clsBusinessObject
    {
        public string FolderLocation { get; set; }
        string separator = Constants.Separator;
        public ContactDirection Direction { get; set; }
        private readonly ElasticsearchClient _client = new clsElasticsearchClientFactory().CreateClient();
        public List<clsContact> contacts { get; private set; }
        public clsContact()
        {
            contacts = new List<clsContact>();
        }
        public override short Read()
        {
            base.Read();
            string SQLCommand = $"SELECT ID, FolderLocation, ContactDirection FROM T_Contact WHERE ID = '{ID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
                short status=dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                ID = queryResArray[1, 1];
                FolderLocation = queryResArray[1, 2];
                Direction = (ContactDirection)Enum.Parse(typeof(ContactDirection), queryResArray[1, 3]);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during read: " + ex.Message);
                return -1;
            }
        }//Read
        public bool ContactExistsInDatabase(string contactID)
        {
            string SQLCommand = $"SELECT ID FROM T_Contact WHERE ID = '{contactID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
            return maxRows == 1;
        }//ContactExistsInDatabase
        public override short Insert()
        {
            base.Insert();
            string SQLCommand = $"INSERT INTO T_Contact (ID, FolderLocation, ContactDirection) " +
            $"VALUES ('{ID}', '{FolderLocation}', '{Direction}')";
            try
            {
                short status = dBConn.RunSQLCommand(SQLCommand);
                string updateSQLCommand = $"UPDATE T_Contact " +
                    $"SET ContactDirectionInt = CASE " +
                    $"    WHEN ContactDirection = 'TX' THEN 0 " +
                    $"    WHEN ContactDirection = 'RX' THEN 1 " +
                    $"    ELSE -1 " +
                    $"END " +
                    $"WHERE ID = '{ID}'";
                dBConn.RunSQLCommand(updateSQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during  insert: " + ex.Message);
                return -1;
            }
        }//Insert
        public override short Update()
        {
            base.Update();
            string SQLCommand = $"UPDATE T_Contact SET  FolderLocation='{FolderLocation}', " +
                        $"ContactDirection='{Direction}' WHERE ID='{ID}'";
            try
            {
                short status = dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during update: " + ex.Message);
                return -1;
            }
        }//Update
        public void ReceiveFilesFromFolders()
        {
            ReceiveFilesFromRXContacts();
        }//ReceiveFilesFromFolders
        public void ReceiveFilesFromRXContacts()
        {
            try
            {
                clsContactQuery contactQuery = new clsContactQuery();
                contactQuery.RunDB();
                foreach (var rxContact in contactQuery.Contacts.Where(c => c.Direction == ContactDirection.RX))
                {
                    string folderPath = rxContact.FolderLocation;

                    if (!Directory.Exists(folderPath))
                    {
                        continue;
                    }

                    DateTime lastReceptionTime = GetLastReceptionTime(folderPath);
                    string[] files = Directory.GetFiles(folderPath);

                    foreach (string filePath in files)
                    {
                        try
                        {
                            ProcessFile(rxContact, filePath, lastReceptionTime);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while processing file {filePath}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during file receiving: " + ex.Message);
            }
        }//ReceiveFilesFromRXContacts
        private void ProcessFile(clsContact contact, string filePath, DateTime lastReceptionTime)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.LastWriteTime <= lastReceptionTime)
            {
                return;
            }
            string content = File.ReadAllText(filePath);

            if (content.Contains("#%%%#Health#%%%#") || content.Contains("#%%%#Sports#%%%#") || content.Contains("#%%%#General#%%%#") || content.Contains("#%%%#Politics#%%%#"))
            {
                ProcessDataFile(content, filePath, "News");
            }
            else
            {
                ProcessDataFile(content, filePath, "Photo");
            }

            UpdateLastReceptionTime(contact.FolderLocation, DateTime.Now);
        }//ProcessFile
        private void ProcessDataFile(string content, string filePath, string fileType)
        {
            if (fileType == "News")
            {
                var news = new clsNews();
                news.AddNewsToFile(content, Path.GetFileNameWithoutExtension(filePath));
            }
            else if (fileType == "Photo")
            {
                var photo = new clsPhoto();
                photo.AddPhotoToFile(content, Path.GetFileNameWithoutExtension(filePath));
            }
        }//ProcessDataFile
        private DateTime GetLastReceptionTime(string folderPath)
        {
            string SQLCommand = $"SELECT LastReceptionDate FROM T_Contact WHERE FolderLocation = '{folderPath}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            DateTime lastReceptionTime = DateTime.MinValue;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);

                if (maxRows > 0)
                {
                    string lastReceptionDateString = queryResArray[1, 1];
                    if (DateTime.TryParse(lastReceptionDateString, out lastReceptionTime))
                    {
                        return lastReceptionTime;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving last reception time: " + ex.Message);
            }
            return lastReceptionTime;
        }//GetLastReceptionTime
        public short UpdateLastReceptionTime(string folderPath, DateTime newReceptionTime)
        {
            string SQLCommand = $"UPDATE T_Contact SET LastReceptionDate = '{newReceptionTime}' WHERE FolderLocation = '{folderPath}'";
            try
            {
                short status = dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during updating last reception date: " + ex.Message);
                return - 1;
            }
        }//UpdateLastReceptionTime
        public void SendItemsToContactFolders(List<ListViewItem> selectedItems, List<clsContact> selectedContacts)
        {
            foreach (ListViewItem selectedItem in selectedItems)
            {
                string tag = selectedItem.Tag.ToString();
                string[] tagParts = tag.Split('|');
                string fileType = tagParts[0];
                string id = tagParts[1];
                string data = GetDataForItem(fileType, id);
                string imagePath = (fileType == "Photos") ? GetImagePath(id) : null;
                SaveDataForContacts(data, selectedContacts);
                SaveDataForContacts(data, selectedContacts, imagePath);
            }
        }//SendItemsToContactFolders
        private void SaveDataForContacts(string data, List<clsContact> selectedContacts, string imagePath)
        {
            foreach (clsContact contact in selectedContacts)
            {
                string fileNames = Guid.NewGuid().ToString();
                string targetFolderPath = contact.FolderLocation;
                if (imagePath != null)
                {
                    string targetImageFileName = $"{fileNames}.jpg";
                    string targetImagePath = Path.Combine(targetFolderPath, targetImageFileName);
                    File.Copy(imagePath, targetImagePath);
                }
            }
        }//SaveDataForContacts
        private string GetImagePath(string id)
        {
            var photoDB = new clsPhoto();
            photoDB.ID = id;
            photoDB.Read();
            return photoDB.PhotoPath;
        }//GetImagePath
        private string GetDataForItem(string fileType, string id)
        {
            if (fileType == "Photos")
            {
                var photoDB = new clsPhoto();
                photoDB.ID = id;
                photoDB.Read();
                return $"{photoDB.Name}{separator}{photoDB.CreationDate}{separator}{photoDB.Description}{separator}{photoDB.PhotoPath}{separator}{photoDB.Body}{separator}{photoDB.LastModifier}";
            }
            else if (fileType == "News")
            {
                var newsDB = new clsNews();
                newsDB.ID = id;
                newsDB.Read();
                return $"{newsDB.Name}{separator}{newsDB.CreationDate}{separator}{newsDB.Description}{separator}{newsDB.Category}{separator}{newsDB.Body}{separator}{newsDB.LastModifier}";
            }
            else
            {
                return string.Empty;
            }
        }//GetDataForItem
        private void SaveDataForContacts(string data, List<clsContact> selectedContacts)
        {
            foreach (clsContact contact in selectedContacts)
            {
                string fileNames = Guid.NewGuid().ToString();
                string targetFolderPath = contact.FolderLocation;
                string targetFilePath = Path.Combine(targetFolderPath, $"{fileNames}.txt");
                File.WriteAllText(targetFilePath, data);
            }
        }//SaveDataForContacts
        public async Task<bool> UpdateContactInElasticsearchAsync(clsContact contact)
        {
            var response = await _client.UpdateAsync<clsContact, clsContact>("my-contact-index", contact.ID, u => u
                .Doc(contact));

            if (response.IsValidResponse)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error occurred during update: ");
                return false;
            }
        }
        public async Task<bool> DeleteContactFromElasticsearchAsync(string contactId)
        {
            var response = await _client.DeleteAsync("my-contact-index", contactId);

            if (response.IsValidResponse)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error occurred during delete: ");
                return false;
            }
        }
        public async Task<bool> InsertContactInElasticsearchAsync(clsContact contact)
        {
            var response = await _client.IndexAsync(contact, "my-contact-index");

            if (response.IsValidResponse)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error occurred during insert: ");
                return false;
            }
        }
    }
    public enum ContactDirection
    {
        TX,
        RX
    }//ContactDirection
}
