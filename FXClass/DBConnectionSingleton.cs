using static DBConnNET4.clsDBConnection;

namespace FileWorxServer
{
    public class DBConnectionSingleton
    {
        private static DBConnNET4.clsDBConnection _instance;
        private DBConnectionSingleton() { }

        public static DBConnNET4.clsDBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnNET4.clsDBConnection();
                _instance.SetDBConn(eDBConnectionType.SQLServer, Constants.ConnectionString);
                short ver = _instance.CheckDBConnection(true);
            }

            return _instance;
        }
    }

}
