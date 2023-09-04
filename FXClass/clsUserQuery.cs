using DBConnNET4;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorxServer
{
    public class clsUserQuery
    {
        public List<clsUser> UserList { get; set; } = new List<clsUser>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        private readonly ElasticsearchClient _client = new clsElasticsearchClientFactory("my-user-index").CreateClient();
        public ClassIds QClasses { get; set; }
        public clsUserQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void RunDB()
        {
            RetrieveFromDataBase();
        }//RunDB
        private void RetrieveFromDataBase()
        {
            using (var dbConn = new clsDBConnection())
            {
                string SQLCommand = $"SELECT B.C_NAME, B.ID, U.UserName, U.Password " +
                                    $"FROM T_BusinessObject B " +
                                    $"INNER JOIN T_User U ON B.ID = U.ID " +
                                    $"WHERE B.C_ClassID = {(int)ClassIds.User}";
                string[,] queryResArray = null;
                int maxRows = 0;
                short maxColumns = 0;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                for (int row = 1; row <= maxRows; row++)
                {
                    clsUser user = new clsUser()
                    {
                        Name = queryResArray[row, 1],
                        ID = queryResArray[row, 2],
                        UserName = queryResArray[row, 3],
                        Password = queryResArray[row, 4]
                    };
                    UserList.Add(user);

                }
            }

        }//RetrieveFromDataBase

        public async Task RunES()
        { 
            await RetrieveFromElasticsearchAsync();
        }//RunES
        private async Task RetrieveFromElasticsearchAsync()
        {
                var searchResponse = await _client.SearchAsync<clsUser>(s => s
                .Query(q => q.MatchAll())
                .Size(1000));

                if (searchResponse.IsValidResponse)
                {
                    foreach (var hit in searchResponse.Hits)
                    {
                        var source = hit.Source;
                        clsUser user = new clsUser()
                        {
                            Name = source.Name,
                            ID = source.ID,
                            UserName = source.UserName,
                            Password = source.Password
                        };
                        UserList.Add(user);
                    }
                }
                else
                {
                    Console.WriteLine("Error occurred during Elasticsearch query: " + searchResponse.DebugInformation);
                }
        }//RetrieveFromElasticsearchAsync

    }
}
