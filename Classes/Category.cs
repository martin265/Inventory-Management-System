using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using InventoryManagementSystem.DB_connection;
using System.Windows.Forms;


namespace InventoryManagementSystem.Classes
{
    class Category
    {
        private int category_id;
        private string category_name;
        private string category_description;
        private string category_status;
        private string category_time;
        private string category_date;

        public int CategoryID { get { return category_id; } set { category_id = value; } }
        public string CategoryName { get { return category_name; } set { category_name = value; } }
        public string CategoryDescription { get { return category_description; } set { category_description = value; } }
        public string CategoryStatus { get { return category_status; } set { category_status = value; } }
        public string CategoryTime { get { return category_time; } set { category_time = value; } }
        public string CategoryDate { get { return category_date; } set { category_date = value; } }

        Connection conn = new Connection(); //  the object for the connection class

        public void Addcategory()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Categories WHERE category_name = '" + category_name + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;

                if (counter > 0)
                {
                    MessageBox.Show("that category already exists in the database");
                }
                else
                {
                    sql = "INSERT INTO Categories(category_name, category_description, category_status, category_time, category_date)" +
                        "VALUES('" + category_name + "', '" + category_description + "', '" + category_status + "', '" + category_time + "', '"+category_time+"');";
                    //sql = "INSERT INTO Category('"+category_name+"', '"+category_description+"', '"+category_status+"', '"+category_time+"');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery(); // running the query
                    MessageBox.Show("category details added successfully");
                    
                }
                connection.Close(); // closing the connection with the database

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// the method to update the category details
        /// </summary>
        public void updateCategory()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "UPDATE Categories SET category_name = '" + category_name + "', category_description = '" + category_description + "', category_status = '" + category_status + "', category_time = '" + category_time + "' WHERE id = '" + category_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query
                MessageBox.Show("details updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void deleteCategory()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "DELETE FROM Categories WHERE id = '" + category_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query

                MessageBox.Show("details updated deleted successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
