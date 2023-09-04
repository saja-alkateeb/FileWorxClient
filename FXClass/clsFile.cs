using System;

namespace FileWorxServer
{

    public class clsFile : clsBusinessObject
    {
        public string Body { get; set; }
        public string FileName { get; set; }
        public clsPhoto Photo { get; set; }
        public clsNews News { get; set; }
        public string PhotoPath { get;  set; }
        public string Category { get;  set; }

        public override short Read()
        {
            base.Read();
             string SQLCommand = $"SELECT C_Body FROM T_File WHERE ID='{ID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try 
            {
               short status= dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                Body = queryResArray[1, 1];
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
            string SQLCommand = $"INSERT INTO T_File (ID, C_Body) VALUES ('{ID}', '{Body}')";
            try
            {
               short status= dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during insert: " + ex.Message);
                return -1;
            }
        }//Insert
        public override short Update()
        {
            base.Update();
            string SQLCommand = $"UPDATE T_File SET C_Body = '{Body}' WHERE ID = '{ID}'";
            try
            {
                short status = dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during insert: " + ex.Message);
                return -1;
            }
        }//Update
    }
}
