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
    class Product
    {


        private int product_id;
        private string product_name;
        private string brand_name;
        private string product_description;
        private int product_quantity;
        private string product_category;
        private int product_price;
        private string bar_code;
        private string product_status;
        private string supplier_name;
        private string product_time;
        private string product_date;


        /// <summary>
        /// the getters and setters for the system
        /// </summary>
        public int ProductID { get { return product_id; } set { product_id = value; } }
        public string ProductName { get { return product_name; } set { product_name = value; } }
        public string BrandName { get { return brand_name; } set { brand_name = value; } }
        public string ProductDescription { get { return product_description; } set { product_description = value; } }
        public int ProductQuantity { get { return product_quantity; } set { product_quantity = value; } }
        public string ProductCategory { get { return product_category; } set { product_category = value; } }
        public int ProductPrice { get { return product_price; } set { product_price = value; } }
        public string BarCode { get { return bar_code; } set { bar_code = value; } }
        public string ProductStatus { get { return product_status; } set { product_status = value; } }
        public string Supplier { get { return supplier_name; } set { supplier_name = value; } }
        public string ProductAddedTime { get { return product_time; } set { product_time = value; } }
        public string ProductDate { get { return product_date; } set { product_date = value; } }

        Connection conn = new Connection(); // the connection object for the system


        /// <summary>
        /// method to add new product to the system
        /// </summary>
        public void addProduct()
        {

            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); //opening the connection with the database
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Product WHERE product_name = '" + product_name + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the sql query

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;

                if (counter > 0)
                {
                    MessageBox.Show("that product already exist in the database");
                }
                else
                {
                    sql = "INSERT INTO Product(product_name, brand_name, product_description, product_quantity, product_category, product_price, bar_code, product_status, supplier_name, product_time, product_date)" +
                        "VALUES('" + product_name + "', '" + brand_name + "', '" + product_description + "', '" + product_quantity + "', '" + product_category + "', '" + product_price + "', '" + bar_code + "', '" + product_status + "', '" + supplier_name + "', '" + product_time + "', '"+product_date+"');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery(); //running the query for the system

                    if (cmd.CommandTimeout > 20000)
                    {
                        MessageBox.Show("the system took too long to process the information");
                    }
                    else
                    {
                        MessageBox.Show("product details added succesfully");
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
        /// the method to update the product details
        /// </summary>
        public void updateProducts()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection with the  database
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "UPDATE Product SET product_name = '" + product_name + "', " +
                    "brand_name = '" + brand_name + "', product_description = '" + product_description + "'," +
                    "product_quantity = '" + product_quantity + "', product_category = '" + product_category + "', " +
                    "product_price = '" + product_price + "', bar_code = '" + bar_code + "', " +
                    "product_status = '" + product_status + "', supplier_name = '"+supplier_name+"',  product_time = '" + product_time + "', product_date = '"+product_date+"' WHERE id = '" + product_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query for the database

                if (cmd.CommandTimeout > 20000)
                {
                    MessageBox.Show("the system took too long to process the information");
                }
                else
                {
                    MessageBox.Show("product details have been updated successfully");
                }
                connection.Close();

            }
            catch (Exception ex)m
            {
                MessageBox.Show(ex.Message);
            }

        }



        /// <summary>
        /// the method to delete the products
        /// </summary>
        public void deleteProducts()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection with the  database
                SqlCommand cmd = connection.CreateCommand();
                sql = "DELETE FROM Product WHERE id = '" + product_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                
                MessageBox.Show("the product details have been deleted successfully");
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
