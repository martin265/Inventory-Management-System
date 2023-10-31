using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InventoryManagementSystem.DB_connection;
using InventoryManagementSystem.Panels;
using InventoryManagementSystem.PanelUserControls;
using System.Windows.Forms;
using System.Data;



namespace InventoryManagementSystem.Classes
{
    /// <summary>
    /// class to add staff permissions
    /// </summary>
    internal class Permission
    {
        private string permission_name;
        private int staff_id;

        public string PermissionName { get { return permission_name; } set { permission_name = value; } }
        public int StaffID { get { return staff_id; } set { staff_id = value; } }


        Connection conn = new Connection(); // the connection
        public void AddPermission()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                sql = "SELECT * FROM Permission WHERE permission_name = '" + permission_name + "';";
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                int counter = ds.Tables[0].Rows.Count;
                if(counter > 0)
                {
                    MessageBox.Show("that staff already has those permissions");
                }
                else
                {
                    sql = "INSERT INTO Permission(permission_name, staff_id) VALUES ('" + permission_name + "', '" + staff_id + "');";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery(); // running the query
                    MessageBox.Show("Permission added successfully");

                }
                connection.Close(); // closing the connection

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
