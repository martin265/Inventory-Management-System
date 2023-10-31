using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.DB_connection;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace InventoryManagementSystem.Classes
{
    class Schedule
    {

        private int event_id;
        private string supplier_email;
        private string event_name;
        private string event_date;


        public int EventID { get { return event_id; } set { event_id = value; } }
        public string SupplierEmail { get { return supplier_email; } set { supplier_email = value; } }
        public string EventName { get { return event_name; } set { event_name = value; } }
        public string EventDate { get { return event_date; } set { event_date = value; } }

        Connection conn = new Connection(); // the connection object with the database

        public void addEvent()
        {
            string sql = conn.sqlConn();
            SqlConnection connection = new SqlConnection(sql);

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            sql = "SELECT * FROM Schedule WHERE event_name = '" + event_name + "';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery(); //running the query for the database

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            int counter = ds.Tables[0].Rows.Count;

            if (counter > 0)
            {
                MessageBox.Show("that event is already set");
            }
            else
            {
                sql = "INSERT INTO Schedule(supplier_name, event_date, event_name) VALUES('"+ supplier_email + "', '"+ event_date + "', '" + event_name + "');";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the database query

                MessageBox.Show("the event has been added successfully");
            }
            connection.Close(); // closing the database connection

        }

    }
}
