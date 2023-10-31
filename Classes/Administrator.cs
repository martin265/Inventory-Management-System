using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using InventoryManagementSystem.DB_connection;
using InventoryManagementSystem.AdminiCredentials;


namespace InventoryManagementSystem.Classes
{

    /// <summary>
    /// the administrator class to register and add new admins
    /// 
    /// </summary>
    /// 

    // getting the current logged in administrator
    
    class Administrator
    {
        public static string Current_username; // the username 

        private int admin_id;
        private string username;
        private string password;
        private string register_time;
        private string register_date;
        


        public int AdminID { get { return admin_id; } set { admin_id = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string RegisterTime { get { return register_time; } set { register_time = value; } }
        public string RegisterDate { get { return register_date; } set { register_date = value; } }
        public static string username_pass = "";

        Connection conn = new Connection(); // the sql connection objec


        public void registerAdmin()
        {
            string sql = conn.sqlConn();
            SqlConnection connection = new SqlConnection(sql);


            connection.Open(); // openign the connection
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            sql = "SELECT * FROM Administrator WHERE username = '"+username+"';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            int counter = ds.Tables[0].Rows.Count;

            if (counter > 0)
            {
                MessageBox.Show("that username or password already exists");
                RegisterDetails registerDetails = new RegisterDetails();
            }
            else
            {
                sql = "INSERT INTO Administrator(username, password, register_time, register_date) VALUES('" + username + "', '" + password + "', '"+register_time+"', '"+register_date+"');";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Administrator details have been registered successfully");
            }
            connection.Close(); // closing the database connection
        }


        public void loginAdministrator()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);


                connection.Open(); // openign the connection
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Administrator WHERE username = '"+username+"' AND password = '"+password+"';";
                cmd.Parameters.Add("@username", username);
                cmd.Parameters.Add("@password", password);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                username_pass = username;
                Current_username = username; // getting the current username for the administrator


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;

                if (counter > 0)
                {
                    MessageBox.Show("you have logged in successfully");
                    Form1 form = new Form1();

                    form.Show();
                }
                else
                {
                    MessageBox.Show("please check your username and password");
                    RegisterDetails registerDetails = new RegisterDetails();
                    registerDetails.Show();

                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void updateAdministrator()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);


                connection.Open(); // openign the connection
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "UPDATE Administrator SET username = '"+username+"', password = '"+password+"' WHERE id = '"+admin_id+"';";
                cmd.CommandText = sql; // binding the data to the sql query
                cmd.ExecuteNonQuery(); // running the database query

                MessageBox.Show("your details have been updated");


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void DeleteAdministrator()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);


                connection.Open(); // openign the connection
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "DELETE FROM Administrator WHERE id = '" + admin_id + "';";
                cmd.CommandText = sql; // binding the data to the sql query
                cmd.ExecuteNonQuery(); // running the database query

                MessageBox.Show("admin details have been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
