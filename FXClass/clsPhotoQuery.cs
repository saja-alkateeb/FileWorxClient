using DBConnNET4;
using System;
using System.Collections.Generic;
namespace FileWorxClient
{
    public class clsPhotoQuery
    {
        public List<clsPhoto> PhotoList { get; set; } = new List<clsPhoto>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        public clsPhotoQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void Run()
        {
            using (var dbConn = new clsDBConnection())
            {
                string SQLCommand = "SELECT B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, P.PhotoPath " +
                "FROM T_BusinessObject B " +
                "INNER JOIN T_Class C ON B.C_ClassID = 2 " +
                "INNER JOIN T_File F ON B.ID = F.ID " +
                "INNER JOIN T_Photo P ON B.ID = P.ID " +
                "GROUP BY B.ID, B.C_Description, B.C_CreationDate, B.C_LastModificationDate, B.C_ClassID, B.C_NAME, B.LastModifier, B.Creator, F.C_Body, P.PhotoPath";
                string[,] queryResArray = null;
                int maxRows = 10;
                short maxColumns = 10;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                for (int row = 1; row <= maxRows; row++)
                {
                    clsPhoto photo = new clsPhoto()
                    {
                        ID = queryResArray[row, 1],
                        Description = queryResArray[row, 2],
                        CreationDate = DateTime.Parse(queryResArray[row, 3]),
                        ClassID = int.Parse(queryResArray[row, 5]),
                        Name = queryResArray[row, 6],
                        LastModifier = queryResArray[row, 7],
                        Creator = queryResArray[row, 8],
                        Body = queryResArray[row, 9],
                        PhotoPath = queryResArray[row, 10]
                    }; PhotoList.Add(photo);

                }
            }

        }//Run






    }
}
