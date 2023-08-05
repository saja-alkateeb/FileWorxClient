using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileWorxClient
{
    public class clsPhoto : clsFile
    {
        public string PhotoPath { get; set; }
        public string PhotoPathCopy { get; set; }

        public List<clsPhoto> PhotoList { get; set; } = new List<clsPhoto>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        public clsPhoto()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public override void Read()
        {
            base.Read();
            string SQLCommand = "SELECT * FROM T_Photo WHERE ID='" + base.ID + "'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                PhotoPath = queryResArray[1, 2];
                PhotoPathCopy = queryResArray[1, 3];
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Read:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Read
        public override void Insert()
        {

            base.Insert();
            string SQLCommand = "INSERT INTO T_Photo (ID, PhotoPath, PhotoPathCopy) VALUES ('" + base.ID + "','" + PhotoPath + "','" + PhotoPathCopy + "')";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Insert:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//insert

        public override void Update()
        {
            base.Update();
            string SQLCommand = "UPDATE T_Photo SET PhotoPath='" + PhotoPath + "', PhotoPathCopy='" + PhotoPathCopy + "' WHERE ID = '" + base.ID + "'";
            try
            {
                dBConn.RunSQLCommand(SQLCommand);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Update:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Update
        public override void Delete()
        {
            base.Delete();
            try
            {
                if (!string.IsNullOrEmpty(PhotoPath) && File.Exists(PhotoPath))
                {
                    File.Delete(PhotoPath);
                }

                if (!string.IsNullOrEmpty(PhotoPathCopy) && File.Exists(PhotoPathCopy))
                {
                    File.Delete(PhotoPathCopy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during file deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Delete


    }
}
