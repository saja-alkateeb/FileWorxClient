using DBConnNET4;
using System.Collections.Generic;
using System;
using System.Linq;
using Elastic.Clients.Elasticsearch;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using Elastic.Transport;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.CodeDom.Compiler;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Xml.Linq;
using Elastic.Clients.Elasticsearch.Core.Search;
namespace FileWorxServer
{
    public class clsFilesQuery
    {
        private readonly ElasticsearchClient _client = new clsElasticsearchClientFactory().CreateClient();
        public ClassIds QClasses { get; set; }
        public List<clsFile> FileDataList { get; set; } = new List<clsFile>();
        private readonly DBConnNET4.clsDBConnection dBConn;

        public clsFilesQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void RunDB(List<ClassIds> classFilters)
        {
            RetrieveFromDataBase(classFilters);
        }
        private void RetrieveFromDataBase(List<ClassIds> classFilters)
        {
            using (var dbConn = new clsDBConnection())
            {
                string classCondition = string.Empty;

                if (classFilters != null && classFilters.Count > 0)
                {
                    string classIds = string.Join(",", classFilters.Select(c => ((int)c).ToString()));
                    classCondition = $"AND B.C_ClassID IN ({classIds}) ";
                }
                string SQLCommand = $"SELECT B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, N.Category, P.PhotoPath " +
                             $"FROM T_BusinessObject B " +
                             $"INNER JOIN T_File F ON B.ID = F.ID " +
                             $"LEFT JOIN T_Photo P ON B.ID = P.ID " +
                             $"LEFT JOIN T_News N ON B.ID = N.ID " +
                             $"WHERE (P.ID IS NOT NULL OR N.ID IS NOT NULL) {classCondition}";

                string[,] queryResArray = null;
                int maxRows = 0;
                short maxColumns = 0;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);

                List<clsFile> files = new List<clsFile>();
                for (int row = 1; row <= maxRows; row++)
                {
                    clsFile fileData = CreateFileDataFromQueryResult(queryResArray, row);
                    files.Add(fileData);
                }
                FileDataList.AddRange(files);
            }
        }//RetrieveFromDataBase
        private clsFile CreateFileDataFromQueryResult(string[,] queryResArray, int row)
        {
            clsFile fileData = new clsFile()
            {
                ID = queryResArray[row, 1],
                Description = queryResArray[row, 2],
                CreationDate = DateTime.Parse(queryResArray[row, 3]),
                ClassID = int.Parse(queryResArray[row, 5]),
                Name = queryResArray[row, 6],
                LastModifier = queryResArray[row, 7],
                Creator = queryResArray[row, 8],
                Body = queryResArray[row, 9],
            };
            if (!string.IsNullOrEmpty(queryResArray[row, 11]))
            {
                clsPhoto photoData = new clsPhoto()
                {
                    PhotoPath = queryResArray[row, 11]
                };
                fileData.Photo = photoData;
            }
            if (!string.IsNullOrEmpty(queryResArray[row, 10]))
            {
                clsNews newsData = new clsNews()
                {
                    Category = queryResArray[row, 10]
                };
                fileData.News = newsData;
            }
            return fileData;
        }

        public async Task RunES(List<ClassIds> classFilters)
        {
            await RetrieveFromElasticsearchAsync("my-files-alias", classFilters);
        }//RunES
        private async Task RetrieveFromElasticsearchAsync(string aliasName, List<ClassIds> classFilters)
        {
            foreach (ClassIds classFilter in classFilters)
            {
                    var searchResponse = await _client.SearchAsync<clsFile>(s => s
                        .Index(aliasName)
                        .Query(q => q
                            .Bool(b => b
                                .Filter(filter => filter
                                    .Term(term => term.Field(f => f.ClassID).Value((int)classFilter))
                                )
                            )
                        )
                        .Size(1000));

                    if (searchResponse.IsValidResponse)
                    {
                        foreach (var hit in searchResponse.Hits)
                        {
                            clsFile fileData = CreateFileDataFromElasticsearch(hit.Source);
                            FileDataList.Add(fileData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error occurred during Elasticsearch query for index " + searchResponse.DebugInformation);
                    }
                
            }
        }//RetrieveFromElasticsearchAsync
        private clsFile CreateFileDataFromElasticsearch(clsFile source)
        {
            clsFile fileData = new clsFile()
            {
                ID = source.ID,
                Description = source.Description,
                CreationDate = source.CreationDate,
                ClassID = source.ClassID,
                Name = source.Name,
                LastModifier = source.LastModifier,
                Creator = source.Creator,
                Body = source.Body
            };
            if (!string.IsNullOrEmpty(source.PhotoPath)) //PhotoPath
            {
                clsPhoto photoData = new clsPhoto()
                {
                    PhotoPath = source.PhotoPath
                };
                fileData.Photo = photoData;
            }

            if (!string.IsNullOrEmpty(source.Category)) //Category
            {
                clsNews newsData = new clsNews()
                {
                    Category = source.Category
                };
                fileData.News = newsData;
            }
            return fileData;
        }


    }
}