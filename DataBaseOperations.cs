using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMAster
{
    public class DataBaseOperations : IDataBaseOperations
    {
        public void Save(NewCinemaHall hall)
        {                
                SqlCommand cmdProdukty = DataBase.dbInstance.sqlCon.CreateCommand();
                cmdProdukty.CommandType = CommandType.Text;
                cmdProdukty.CommandText = "INSERT INTO Room (name, rows, columns,totalChairs)VALUES('" + hall.hallName + "','" + hall.rows + "','" + hall.columns + "','" + hall.chairsInHall + "')";
                cmdProdukty.ExecuteNonQuery();           
        }
    }
}
