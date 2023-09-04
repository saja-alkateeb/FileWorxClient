using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorxServer
{
    public class clsContactQuery
    {
        private readonly DBConnNET4.clsDBConnection dBConn;
        public List<clsContact> Contacts { get; set; } = new List<clsContact>();
        private readonly ElasticsearchClient _client = new clsElasticsearchClientFactory("my-contact-index").CreateClient();
        public clsContactQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void RunDB()
        {
           RetrieveFromDataBase();
        }//RunDB
        private void RetrieveFromDataBase()
        {
            string SQLCommand = $"SELECT bc.ID, bo.C_NAME, bc.FolderLocation, bc.Contactdirection, bo.* " +
                        $"FROM T_Contact bc " +
                        $"INNER JOIN T_BusinessObject bo ON bc.ID = bo.ID ";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                for (int i = 1; i <= maxRows; i++)
                {
                    clsContact contact = new clsContact
                    {
                        ID = queryResArray[i, 1],
                        Name = queryResArray[i, 2],
                        FolderLocation = queryResArray[i, 3],
                        Direction = (ContactDirection)Enum.Parse(typeof(ContactDirection), queryResArray[i, 4])
                    };
                    Contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during database query: " + ex.Message);
            }
        }// RetrieveFromDataBase
        public async Task RunAsync()
        {
            await  RetrieveFromElasticsearchAsync();
        }//RunAsync
        private async Task RetrieveFromElasticsearchAsync()
        {
            var searchResponse = await _client.SearchAsync<clsContact>(s => s
                .Query(q => q.MatchAll())
                .Size(1000));

            if (searchResponse.IsValidResponse)
            {
                foreach (var hit in searchResponse.Hits)
                {
                    var source = hit.Source;
                    clsContact contact = new clsContact
                    {
                        ID = source.ID,
                        Name = source.Name,
                        FolderLocation = source.FolderLocation,
                        Direction = (ContactDirection)Enum.Parse(typeof(ContactDirection), source.Direction.ToString())
                    };
                    Contacts.Add(contact);
                }
            }
            else
            {
                Console.WriteLine("Error occurred during Elasticsearch query: " + searchResponse.DebugInformation);
            }
        }//RetrieveFromElasticsearchAsync

    }
}
