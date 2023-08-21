using System;
using System.Windows.Forms;

namespace FileWorxServer
{
    public class clsUser : clsBusinessObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public override short Insert()
        {
            try
            {
                base.Insert();
                if (!IsUserNameExists(UserName))
                {
                    Console.WriteLine("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                {
                    string SQLCommand = $"INSERT INTO T_User (ID, UserName, Password) VALUES ('{ID}', '{UserName}', '{Password}')";
                    short status=dBConn.RunSQLCommand(SQLCommand);
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during insert: " + ex.Message);
                return -1;
            }
        }
        public bool IsUserNameExists(string userName)
        {
            string SQLCommand = $"SELECT * FROM T_User WHERE UserName='{UserName}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
            if (maxRows > 0)
            {
                return false;
            }
            return true;
        }
        public string GetUser(string password)
        {
            string SQLCommand = $"SELECT ID FROM T_User WHERE Password='{password}'";
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
            string SQLCommand = $"SELECT * FROM T_User WHERE UserName='{UserName}' AND Password='{Password}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
            if (maxRows > 0)
            {
                return true;
            }

            return false;

        }//IsLoginValid
        public string GetUserNameByID(string userID)
        {
            try
            {
                string SQLCommand = $"SELECT UserName FROM T_User WHERE ID = '{userID}'";
                string[,] queryResArray = null;
                int maxRows = 0;
                short maxColumns = 0;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);

                if (maxRows > 0)
                {
                    return queryResArray[1, 1];
                }
                else
                {
                    return "Unknown User";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting user name: " + ex.Message);
                return "Error";
            }
        }//GetUserNameByID
        public override short Read()
        {
            base.Read();
            string SQLCommand = $"SELECT UserName, Password FROM T_User WHERE ID='{ID}'";
            string[,] queryResArray = null;
            int maxRows = 10;
            short maxColumns = 10;
            try
            {
                short status=dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns, 1, 1);
                UserName = queryResArray[1, 1];
                Password = queryResArray[1, 2];
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during read: " + ex.Message);
                return -1;
            }
        }//Read

        public override short Update()
        {
            base.Update();

            string SQLCommand = $"UPDATE T_User SET UserName='{UserName}' WHERE ID = '{ID}'";
            try
            {
                short status=dBConn.RunSQLCommand(SQLCommand);
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
