using DBConnNET4;
using System.Collections.Generic;
using System;
namespace FileWorxServer
{ 
    public class clsFilesQuery
    {
        public ClassIds QClasses { get; set; }
        public List<clsFile> FileDataList { get; set; } = new List<clsFile>();
        private readonly DBConnNET4.clsDBConnection dBConn;

        public clsFilesQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }

        public void Run()
        {
            using (var dbConn = new clsDBConnection())
            {
                string classFilter = "";
                if (QClasses != 0)
                {
                    classFilter = $"INNER JOIN T_Class C ON B.C_ClassID = {(int)QClasses} ";
                }
                string SQLCommand = $"SELECT B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, N.Category, P.PhotoPath " +
                    $"FROM T_BusinessObject B {classFilter} " +
                    $"INNER JOIN T_File F ON B.ID = F.ID " +
                    $"LEFT JOIN T_Photo P ON B.ID = P.ID " +
                    $"LEFT JOIN T_News N ON B.ID = N.ID " +
                    $"WHERE P.ID IS NOT NULL OR N.ID IS NOT NULL ";
                string[,] queryResArray = null;
                int maxRows = 0;
                short maxColumns = 0;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);

                for (int row = 1; row <= maxRows; row++)
                {
                    clsFile fileData = new clsFile()
                    {
                        ID = queryResArray[row, 1],
                        Description = queryResArray[row, 2],
                        CreationDate = DateTime.Parse(queryResArray[row, 3]),
                        // LastModificationDate = DateTime.Parse(queryResArray[row, 4])
                        ClassID = int.Parse(queryResArray[row, 5]),
                        Name = queryResArray[row, 6],
                        LastModifier = queryResArray[row, 7],
                        Creator = queryResArray[row, 8],
                        Body = queryResArray[row, 9],

                    };
                    if (!string.IsNullOrEmpty(queryResArray[row, 11])) // PhotoPath
                    {
                        clsPhoto photoData = new clsPhoto()
                        {
                            PhotoPath = queryResArray[row, 11]
                        };
                        fileData.clsPhoto = photoData;
                    }

                    if (!string.IsNullOrEmpty(queryResArray[row, 10])) // Category
                    {
                        clsNews newsData = new clsNews()
                        {
                            Category = queryResArray[row, 10]
                        };
                        fileData.clsNews = newsData;
                    }
                    FileDataList.Add(fileData);
                }
            }
        }
    }
}