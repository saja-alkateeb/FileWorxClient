using DBConnNET4;
using System;
using System.Collections.Generic;

namespace FileWorxClient
{
    public class clsNewsQuery
    {
        //DBConnNET4.clsDBConnection dBConn = new clsDBConnection();
        public List<clsNews> NewsList { get; set; } = new List<clsNews>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        public clsNewsQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void Run()
        {
            using (var dbConn = new clsDBConnection())
            {
                string SQLCommand = "SELECT B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, N.Category " +
                                    "FROM T_BusinessObject B " +
                                    "INNER JOIN T_Class C ON B.C_ClassID = 1 " +
                                    "INNER JOIN T_File F ON B.ID = F.ID " +
                                    "INNER JOIN T_News N ON B.ID = N.ID " +
                                    "GROUP BY B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, N.Category";
                string[,] queryResArray = null;
                int maxRows = 10;
                short maxColumns = 10;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                for (int row = 1; row <= maxRows; row++)
                {
                    clsNews news = new clsNews()
                    {
                        ID = queryResArray[row, 1],
                        Description = queryResArray[row, 2],
                        CreationDate = DateTime.Parse(queryResArray[row, 3]),
                        ClassID = int.Parse(queryResArray[row, 5]),
                        Name = queryResArray[row, 6],
                        LastModifier = queryResArray[row, 7],
                        Creator = queryResArray[row, 8],
                        Body = queryResArray[row, 9],
                        Category = queryResArray[row, 10]

                    }; NewsList.Add(news);
                }
            }

        }//Run






    }
}
