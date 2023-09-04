using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Elastic.Clients.Elasticsearch.QueryDsl;
namespace FileWorxServer
{
    public class clsPhoto : clsFile
    {
        public string PhotoPath { get; set; }
        public string PhotoPathCopy { get; set; }
        string separator = Constants.Separator;
        private readonly ElasticsearchClient _client = new clsElasticsearchClientFactory().CreateClient();
        public override short Read()
        {
            base.Read();
            string SQLCommand = $"SELECT PhotoPath, PhotoPathCopy FROM T_Photo WHERE ID='{ID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
               short status= dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                PhotoPath = queryResArray[1, 1];
                PhotoPathCopy = queryResArray[1, 2];
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during read: " + ex.Message);
                return -1;
            }
        }//Read
        public override short Insert()
        {

            base.Insert();
            string SQLCommand = $"INSERT INTO T_Photo (ID, PhotoPath, PhotoPathCopy) VALUES ('{ID}', '{PhotoPath}', '{PhotoPathCopy}')";
            try
            {
                short status=dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during insert: " + ex.Message);
                return -1;
            }
        }//insert

        public override short Update()
        {
            base.Update();
            string SQLCommand = $"UPDATE T_Photo SET PhotoPath='{PhotoPath}', PhotoPathCopy='{PhotoPathCopy}' WHERE ID = '{ID}'";
            try
            {
               short status= dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during update: " + ex.Message);
                return -1;
            }
        }//Update
        public override short Delete()
        {
            base.Delete();
            try
            {
                if (!string.IsNullOrEmpty(PhotoPath) && File.Exists(PhotoPath))
                {
                    File.Delete(PhotoPath);
                }

                if (!string.IsNullOrEmpty(PhotoPathCopy) && File.Exists(PhotoPathCopy))
                {
                    File.Delete(PhotoPathCopy);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during file deletion: " + ex.Message);
                return -1;
            }
        }//Delete
        public void AddPhotoToFile(string content, string fileName)
        {
            string[] photoParts = content.Split(new[] { separator }, StringSplitOptions.None);
            Name = photoParts[0];
            CreationDate = DateTime.Parse(photoParts[1]);
            Description = photoParts[2];
            PhotoPath = photoParts[3];
            Body = photoParts[4];
            LastModifier = photoParts[5];
            string copiedFileName = Path.Combine("ImageCopies", Guid.NewGuid().ToString() + Path.GetExtension(PhotoPath));
            string destinationPath = Path.Combine(Application.StartupPath, copiedFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
            File.Copy(PhotoPath, destinationPath);
            PhotoPathCopy = destinationPath;
            clsClass classDB = new clsClass();
            ClassID = (int)ClassIds.Photo;
            ID = Guid.NewGuid().ToString();
            FileName = fileName;
            Insert();
        }
        public async Task<bool> UpdatePhotoInElasticsearchAsync(clsPhoto photo)
        {
            var response = await _client.UpdateAsync<clsPhoto, clsPhoto>("my-photo-index", photo.ID, u => u
                .Doc(photo));

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
        public async Task<bool> DeletePhotoFromElasticsearchAsync(string photoId)
        {
            var response = await _client.DeleteAsync("my-photo-index", photoId);

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
        public async Task<bool> InsertPhotoInElasticsearchAsync(clsPhoto photo)
        {
            var response = await _client.IndexAsync(photo, "my-photo-index");

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
}
