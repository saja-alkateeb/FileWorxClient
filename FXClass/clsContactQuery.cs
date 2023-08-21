using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorxServer
{
    public class clsContactQuery
    {
        private readonly DBConnNET4.clsDBConnection dBConn;
        public List<clsContact> contacts { get; set; } = new List<clsContact>();
        public clsContactQuery()
        {
            dBConn = DBConnectionSingleton.GetInstance();
        }
        public void Run()
        {
            string SQLCommand = $"SELECT bc.ID, bo.C_NAME, bc.FolderLocation, bc.Contactdirection, bo.* " +
                        $"FROM T_Contact bc " +
                        $"INNER JOIN T_BusinessObject bo ON bc.ID = bo.ID ";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
                dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                for (int i = 1; i <= maxRows; i++)
                {
                    clsContact contact = new clsContact
                    {
                        ID = queryResArray[i, 1],
                        Name = queryResArray[i, 2],
                        FolderLocation = queryResArray[i, 3],
                        Direction = (ContactDirection)Enum.Parse(typeof(ContactDirection), queryResArray[i, 4])
                    };
                    contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during database query: " + ex.Message);
            }
        }
    }
}
