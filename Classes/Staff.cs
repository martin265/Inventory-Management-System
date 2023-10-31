using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagementSystem.DB_connection;


namespace InventoryManagementSystem.Classes
{
    class Staff
    {

        private int staff_id;
        private string first_name;
        private string last_name;
        private string email;
        private string gender;
        private string username;
        private string department;
        private string status;
        private string password;
        private string register_time;
        private string register_date;

        public int StaffID { get { return staff_id; } set { staff_id = value; } }
        public string FirstName { get { return first_name; } set { first_name = value; } }
        public string LastName { get { return last_name; } set { last_name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Department { get { return department; } set { department = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string RegisterTime { get { return register_time; } set { register_time = value; } }
        public string RegisterDate { get { return register_date; } set { register_date = value; } }

        // the database connection
        Connection conn = new Connection();


        /// <summary>
        /// adding a new staff member into the system
        /// </summary>
        public void RegisterStaff()
        {
            try
            {
                string sql = conn.sqlConn(); // the sql connection
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT * FROM Staff WHERE username = '" + username + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query for the site

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;

                if (counter > 0)
                {
                    MessageBox.Show("that username already exists");

                }
                else
                {
                    sql = "INSERT INTO Staff(first_name, last_name, email, gender, department, status, username, password, register_time, register_date)" +
                        "VALUES('" + first_name + "', '" + last_name + "', '" + email + "', '" + gender + "', '" + department + "', '" + status + "', '"+username+"', '" + password + "', '" + register_time + "', '"+register_date+"');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Staff details added successfully");
                }
                connection.Close(); // closing the connection with the database

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void UpdateStaffDetails()
        {
            try
            {
                string sql = conn.sqlConn(); // the sql connection
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "UPDATE Staff SET first_name = '" + first_name + "', last_name = '" + last_name + "', " +
                    "email = '" + email + "', gender = '" + gender + "', department = '" + department + "'," +
                    "status = '" + status + "', username = '"+username+"', password = '"+password+"',  register_time = '" + register_time + "', register_date = '"+register_date+"' WHERE id = '" + staff_id + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query for the site

                MessageBox.Show("staff details have been updated successfully");
                
                connection.Close(); // closing the connection with the database.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// method or function to delete the stuff details
        /// </summary>
        public void DeleteStaffDetails()
        {

            try
            {
                string sql = conn.sqlConn(); // the sql connection
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "DELETE FROM Staff WHERE id = '" + staff_id + "';";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query for the site

                MessageBox.Show("staff details have been deleted successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
