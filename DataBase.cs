using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMAster
{
    public class DataBase
    {
        private DataBase(){}
        public static DataBase dbInstance;

        public SqlConnection sqlCon = new SqlConnection();
        string connectionStatus;

        public static DataBase GetInstance()
        {
            if(dbInstance == null)
            {
                dbInstance = new DataBase();
            }
            return dbInstance;
        }
        public string OpenConnection() 
        {
            try
            {
                sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["CineMaster"].ToString();
                sqlCon.Open();
                connectionStatus = "Połączenie zostało otwarte";
            }
            catch (Exception)
            {

                connectionStatus = "Błąd połączenia do bazy";
            }

            return connectionStatus;
        }
        public void CloseConnection()
        {
            sqlCon.Close();
        }

    }
}
