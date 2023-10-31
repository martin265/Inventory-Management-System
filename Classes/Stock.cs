using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagementSystem.DB_connection;
using System.Data;



namespace InventoryManagementSystem.Classes
{
    class Stock
    {

        /// <summary>
        /// the private attributes for the stcok class
        /// </summary>
        private int stock_id;
        private int stock_number;
        private string product_name;
        private string brand_name;
        private string product_category;
        private int product_price;
        private int product_quantity;
        private int total_price;
        private string supplier_name;
        private string stock_status;
        //private int product_code;
        private string stock_time;
        private string stock_date;

        public int StockID { get { return stock_id; } set { stock_id = value; } }
        public int StockNumber { get { return stock_number; } set { stock_number = value; } }
        public string ProductName { get { return product_name; } set { product_name = value; } }
        public string BrandName { get { return brand_name; } set { brand_name = value; } }
        public string ProductCategory { get { return product_category; } set { product_category = value; } }
        public int ProductPrice { get { return product_price; } set { product_price = value; } }
        public int ProductQuantity { get { return product_quantity; } set { product_quantity = value; } }
        public int TotalPrice { get { return total_price; } set { total_price = value; } }
        public string SupplierName { get { return supplier_name; } set { supplier_name = value; } }
        public string StockStatus { get { return stock_status; } set { stock_status = value; } }
        //public int ProductCode { get { return product_code; } set { product_code = value; } }
        public string StockTime { get { return stock_time; } set { stock_time = value; } }
        public string StockDate { get { return stock_date; } set { stock_date = value; } }

        Connection conn = new Connection(); // the connection object


        public void addStock()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection 
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Stocks WHERE product_name = '" + product_name + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query for the syste,

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds); // filling the data in the datatable

                int counter = ds.Tables[0].Rows.Count; // counting the number of rows

                if (counter > 0)
                {
                    MessageBox.Show("that product is already available in stock");
                }
                else
                {
                    sql = "INSERT INTO Stocks(stock_number, product_name, brand_name, product_category, product_price, product_quantity, total_price, supplier_name, " +
                        "stock_status, stock_time, stock_date) " +
                        "VALUES(" +
                        "'" + stock_number + "', '" + product_name + "', '" + brand_name + "', " +
                        "'" + product_category + "', '" + product_price + "', '" + product_quantity + "', " +
                        "'" + total_price + "', '" + supplier_name + "', '" + stock_status + "', '" + stock_time + "', '" + stock_date + "');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery(); // running the query

                    if (cmd.CommandTimeout > 20000)
                    {
                        MessageBox.Show("the system took too long to process the information");
                    }
                    else
                    {
                        MessageBox.Show("stock details added successfully");
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
        /// method to update the stock details
        /// </summary>
        public void updateStockDetails()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection 
                SqlCommand cmd = connection.CreateCommand();
                sql = "UPDATE Stocks SET stock_number = '" + stock_number + "', product_name = '" + product_name + "', " +
                    "brand_name = '" + brand_name + "', product_category = '" + product_category + "', product_price = '" + product_price + "', " +
                    "product_quantity = '" + product_quantity + "', total_price = '" + total_price + "', supplier_name = '" + supplier_name + "', " +
                    "stock_status = '" + stock_status + "', stock_time = '" + stock_time + "', " +
                    "stock_date = '" + stock_date + "' WHERE id = '" + stock_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the database query

                
                MessageBox.Show("Stock details updated successfully");
                
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void deleteStockDetails()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open(); // opening the connection 
                SqlCommand cmd = connection.CreateCommand();
                sql = "DELETE FROM Stocks WHERE id = '" + stock_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the sql query for the system

                if (cmd.CommandTimeout > 20000)
                {
                    MessageBox.Show("the system took too long to process your information");
                }
                else
                {
                    MessageBox.Show("stock details deleted successfully");
                }
                connection.Close(); // closing the connection with the database
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
