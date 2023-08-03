using System;
using System.Windows.Forms;

namespace FileWorxClient
{
    public class clsBusinessObject
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int ClassID { get; set; }//
        public string LastModifier { get; set; }//User Id 
        private readonly DBConnNET4.clsDBConnection dBConn;
        public string Creator { get; set; }//User Id 
        //public clsUser Creator { get; set; }//User Id 
        public clsBusinessObject()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public virtual void Read()
        {
            string SQLCommand = "SELECT * FROM T_BusinessObject WHERE ID='" + this.ID + "'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                ID = queryResArray[1, 1];
                Description = queryResArray[1, 2];
                CreationDate = DateTime.Parse(queryResArray[1, 3]);
                ClassID = int.Parse(queryResArray[1, 5]);
                Name = queryResArray[1, 6];
                //LastModifier = queryResArray[1, 7];
                Creator = queryResArray[1, 8];
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Read:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Read
        public virtual void Insert()
        {
            string SQLCommand = "INSERT INTO T_BusinessObject(ID,C_Description,C_CreationDate, C_ClassID, C_NAME,Creator)VALUES('" + ID + "','" + Description + "','" + CreationDate + "','" + ClassID + "','" + Name + "','" + Creator + "')";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Insert:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Insert
        public virtual void Delete()
        {
            string SQLCommand = "DELETE FROM T_BusinessObject WHERE ID = '" + this.ID + "'";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {

                MessageBox.Show("Error occurred during Delete:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Delete   

        public virtual void Update()
        {
            LastModificationDate = DateTime.Now;
            string SQLCommand = "UPDATE T_BusinessObject SET C_Description='" + Description + "', C_NAME='" + Name + "', C_ClassID='" + ClassID + "',C_LastModificationDate='" + LastModificationDate + "',LastModifier='" + this.LastModifier + "', Creator='" + Creator + "' WHERE ID = '" + ID + "'";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Update:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//Update
    }

}
