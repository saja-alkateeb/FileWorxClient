using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileWorxClient
{
    public class clsUser : clsBusinessObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<clsUser> UserList { get; set; } = new List<clsUser>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        public clsUser()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public override void Insert()
        {
            try
            {
                base.Insert();
                if (!IsUserNameExists(UserName))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else
                {
                    string SQLCommand = "INSERT INTO T_User (ID, UserName,Password) VALUES ('" + base.ID + "','" + UserName + "','" + Password + "')";
                    dBConn.RunSQLCommand(SQLCommand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the User : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool IsUserNameExists(string userName)
        {
            string SQLCommand = "SELECT * FROM T_User WHERE UserName='" + UserName + "'";
            string[,] queryResArray = null;
            int maxRows = 100;
            short maxColumns = 100;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
            if (maxRows > 0)
            {
                return false;
            }
            return true;
        }
        public string GetUser(string password)
        {
            string SQLCommand = "SELECT ID FROM T_User WHERE Password='" + password + "'";
            string[,] queryResArray = null;
            int maxRows = 100;
            short maxColumns = 100;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
            ID = queryResArray[1, 1];
            return ID;

        }
        public bool IsLoginValid(string username, string password)
        {
            this.UserName = username;
            this.Password = password;

            if (username == "root" && password == "root")
            {
                IsAdmin = true;
                return true;
            }

            // If not "root", check the database for a valid login
            string SQLCommand = "SELECT * FROM T_User WHERE UserName='" + UserName + "' AND Password='" + Password + "'";
            string[,] queryResArray = null;
            int maxRows = 100;
            short maxColumns = 100;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
            if (maxRows > 0)
            {
                return true;
            }

            return false;

        }//IsLoginValid
        public override void Read()
        {
            base.Read();
            string SQLCommand = "SELECT * FROM T_User WHERE ID='" + base.ID + "'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                UserName = queryResArray[1, 2];
                Password = queryResArray[1, 3];
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during Read:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Read

        public override void Update()
        {
            base.Update();

            string SQLCommand = "UPDATE T_User SET UserName='" + UserName + "' WHERE ID = '" + base.ID + "'";
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
