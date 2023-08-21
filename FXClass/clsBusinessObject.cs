using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileWorxServer
{
    public class clsBusinessObject
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int ClassID { get; set; }
        public string LastModifier { get; set; }
        public readonly DBConnNET4.clsDBConnection dBConn;
        public string Creator { get; set; }
        public clsBusinessObject()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public virtual short Read()
        {
            string SQLCommand = $"SELECT ID, C_Description, C_CreationDate, C_ClassID, C_Name, LastModifier, Creator FROM T_BusinessObject WHERE ID='{ID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
                short status=dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                ID = queryResArray[1, 1];
                Description = queryResArray[1, 2];
                CreationDate = DateTime.Parse(queryResArray[1, 3]);
                ClassID = int.Parse(queryResArray[1, 4]);
                Name = queryResArray[1, 5];
                Creator = queryResArray[1, 7];
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during read: " + ex.Message);
                return -1;
            }
        }//Read
        public virtual short Insert()
        {
            string SQLCommand = $"INSERT INTO T_BusinessObject(ID, C_Description, C_CreationDate, C_ClassID, C_NAME, Creator) VALUES ('{ID}', '{Description}', '{CreationDate}', '{ClassID}', '{Name}', '{Creator}')";
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
        }//Insert
        public virtual short Delete()
        {
            string SQLCommand = $"DELETE FROM T_BusinessObject WHERE ID = '{ID}'";
            try
            {
               short status= dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during delete: " + ex.Message);
                return -1;
            }
        }//Delete   
        public virtual short Update()
        {
            LastModificationDate = DateTime.Now;
            //class id should not be updated
            string SQLCommand = $"UPDATE T_BusinessObject SET C_Description='{Description}', C_NAME='{Name}', C_ClassID='{ClassID}', C_LastModificationDate='{LastModificationDate}', LastModifier='{LastModifier}', Creator='{Creator}' WHERE ID = '{ID}'";
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
    }

}
