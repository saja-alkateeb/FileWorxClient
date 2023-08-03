using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnNET4;
using static DBConnNET4.clsDBConnection;

namespace FileWorxClient
{
    public class clsFile:clsBusinessObject
    {
        private readonly DBConnNET4.clsDBConnection dBConn;
        public clsFile()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public string Body { get; set; }
        public override void Read()
        {
            base.Read();
            string SQLCommand = "SELECT * FROM T_File WHERE ID='" + base.ID + "'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                Body = queryResArray[1, 2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during Read:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//Read
        public override void Insert()
        {
            base.Insert();
            string SQLCommand = "INSERT INTO T_File (ID, C_Body) VALUES ('"+ base.ID + "','"+ Body + "')";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during Insert:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Insert
        public override void Update ()
        {
            base.Update();
            string SQLCommand = "UPDATE T_File SET C_Body='" + Body + "' WHERE ID = '" + base.ID + "'";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during Update:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
