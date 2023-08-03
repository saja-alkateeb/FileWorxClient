using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace FileWorxClient
{
    public class clsNews : clsFile
    {
        public string Category { get; set; }
        private readonly DBConnNET4.clsDBConnection dBConn;
        public List<clsNews> NewsList { get; set; } = new List<clsNews>();
        public clsNews()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public override void Read()
        {
            base.Read();
            string SQLCommand = "SELECT * FROM T_News WHERE ID='" + base.ID + "'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                Category = queryResArray[1, 2];
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Read:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Read
        public override void Insert()
        {
            base.Insert();
            string SQLCommand = "INSERT INTO T_News (ID, Category) VALUES ('" + base.ID + "','" + Category + "')";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Insert:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Insert
        public override void Update()
        {
            base.Update();
            string SQLCommand = "UPDATE T_News SET Category='" + Category + "' WHERE ID = '" + base.ID + "'";
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
