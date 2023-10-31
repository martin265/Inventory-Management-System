using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DB_connection
{
    class Connection
    {

        /// <summary>
        /// method to create the connection with the database
        /// </summary>
        /// <returns></returns>
        public string sqlConn()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\martin\source\repos\FINAL-PROJECT\InventoryManagementSystem\InventoryManagementSystem\InventoryDB.mdf;Integrated Security=True";
            return connection;
        }
    }
}
