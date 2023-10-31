using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using InventoryManagementSystem.DB_connection;


namespace InventoryManagementSystem.Classes
{
    class Supplier
    {

        // help me lord in everything....

        private int supplier_id;
        private string supplier_name;
        private string supplier_location;
        private string supplier_email;
        private int phone_number;
        private string supplier_status;
        private string current_time;
        private string current_date;


        public int SupplierID { get { return supplier_id; } set { supplier_id = value; } }
        public string SupplierName { get { return supplier_name; } set { supplier_name = value; } }
        public string SupplierLocation { get { return supplier_location; } set { supplier_location = value; } }
        public string SupplierEmail { get { return supplier_email; } set { supplier_email = value; } }
        public int PhoneNumber { get { return phone_number; } set { phone_number = value; } }
        public string SUpplierStatus { get { return supplier_status; } set { supplier_status = value; } }
        public string CurrentTime { get { return current_time; } set { current_time = value; } }
        public string CurrentDate { get { return current_date; } set { current_date = value; } }

        Connection conn = new Connection(); // the database connection


        /// <summary>
        /// the method to add a new supplier
        /// </summary>
        public void addSupplier()
        {

            try
            {
                string sql = conn.sqlConn(); // the connection with the database
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Supplier WHERE supplier_name = '" + supplier_name + "'; ";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;

                if (counter > 0)
                {
                    MessageBox.Show("that supplier already exists in the database");
                }
                else
                {
                    sql = "INSERT INTO Supplier(supplier_name, supplier_location, supplier_email, phone_number, supplier_status, supplier_time, supplier_date)" +
                        "VALUES('" + supplier_name + "', '" + supplier_location + "', '" + supplier_email + "', '" + phone_number + "', '" + supplier_status + "', '"+current_time+"', '"+current_date+"');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery(); // runnig the sql query 

                    if (cmd.CommandTimeout > 20000)
                    {
                        MessageBox.Show("the system took too long to process the information");
                    }
                    else
                    {
                        MessageBox.Show("the supplier details added successfully");
                    }
                }
                connection.Close(); // closing the connection with the database

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// the method to update the supplier details
        /// </summary>
        public void updateSupplier()
        {

            try
            {
                string sql = conn.sqlConn(); // the connection method
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "UPDATE Supplier SET supplier_name = '" + supplier_name + "', supplier_location = '" + supplier_location + "', " +
                    "supplier_email = '" + supplier_email + "', phone_number = '" + phone_number + "', " +
                    "supplier_status = '" + supplier_status + "' WHERE id  = '" + supplier_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query 

                MessageBox.Show("the supplier details have been updated successfully");
                connection.Close(); // closing the connection with the database

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteSupplier()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection with the database
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "DELETE FROM Supplier WHERE id = '" + SupplierID + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the database query
                
                MessageBox.Show("supplier details deleted successfully");
                
                connection.Close(); // closing the connection

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
