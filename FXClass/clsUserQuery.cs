using DBConnNET4;
using System.Collections.Generic;
namespace FileWorxServer
{
    public class clsUserQuery
    {
        public List<clsUser> UserList { get; set; } = new List<clsUser>();
        private readonly DBConnNET4.clsDBConnection dBConn;
        public ClassIds QClasses { get; set; }
        public clsUserQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void Run()
        {
            using (var dbConn = new clsDBConnection())
            {
                string SQLCommand = $"SELECT B.C_NAME, B.ID, U.UserName, U.Password " +
                                    $"FROM T_BusinessObject B " +
                                    $"INNER JOIN T_User U ON B.ID = U.ID " +
                                    $"WHERE B.C_ClassID = {(int)ClassIds.User}";
                string[,] queryResArray = null;
                int maxRows = 0;
                short maxColumns = 0;
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                for (int row = 1; row <= maxRows; row++)
                {
                    clsUser User = new clsUser()
                    {
                        Name = queryResArray[row, 1],
                        ID = queryResArray[row, 2],
                        UserName = queryResArray[row, 3],
                        Password = queryResArray[row, 4]
                    };
                    UserList.Add(User);

                }
            }

        }//Run
    }
}
