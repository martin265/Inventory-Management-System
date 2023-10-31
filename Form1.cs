using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using InventoryManagementSystem.Panels;
using System.Collections;
using InventoryManagementSystem.DB_connection;
using InventoryManagementSystem.Classes;




namespace InventoryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showUsername();
            //timer1.Start(); // starting the timer
            ShowNotifications();
        }


        Connection conn = new Connection();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                CenterAdminControl centerAdminControl = new CenterAdminControl(); // the admin object
                CenterAdminControl2 centerAdminControl2 = new CenterAdminControl2();
                centerAdminControl.TopLevel = false;
                centerAdminControl2.TopLevel = false;

                CenterFlowPages.Controls.Add(centerAdminControl);
                CenterFlowPages.Controls.Add(centerAdminControl2);
                centerAdminControl.Show(); // displaying the form 
                centerAdminControl2.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                StaffDetails staffDetails = new StaffDetails();
                staffDetails.TopLevel = false;

                CenterFlowPages.Controls.Add(staffDetails);
                staffDetails.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SiticoneButton1_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                CenterAdminControl centerAdminControl = new CenterAdminControl(); // the admin object
                CenterAdminControl2 centerAdminControl2 = new CenterAdminControl2();
                centerAdminControl.TopLevel = false;
                centerAdminControl2.TopLevel = false;

                CenterFlowPages.Controls.Add(centerAdminControl);
                CenterFlowPages.Controls.Add(centerAdminControl2);
                centerAdminControl.Show(); // displaying the form 
                centerAdminControl2.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCategoryDetails_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                CategoryDetails categoryDetails = new CategoryDetails();
                categoryDetails.TopLevel = false;

                CenterFlowPages.Controls.Add(categoryDetails);
                categoryDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                ProductDetails productDetails = new ProductDetails();
                productDetails.TopLevel = false;

                CenterFlowPages.Controls.Add(productDetails);
                productDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {

        }

        private void BtnSupplier_Click_1(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                SupplierDetails supplierDetails = new SupplierDetails();
                supplierDetails.TopLevel = false;

                CenterFlowPages.Controls.Add(supplierDetails);
                supplierDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStockDetails_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                StockDetails stockDetails = new StockDetails();
                stockDetails.TopLevel = false;

                CenterFlowPages.Controls.Add(stockDetails);
                stockDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnScheduleApointment_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                ScheduleAppointments scheduleAppointments = new ScheduleAppointments();
                scheduleAppointments.TopLevel = false;

                CenterFlowPages.Controls.Add(scheduleAppointments);
                scheduleAppointments.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls


                ReportDetails reportDetails = new ReportDetails();
                reportDetails.TopLevel = false;

                ForcastingDetails forcastingDetails = new ForcastingDetails();
                forcastingDetails.TopLevel = false;


                CenterFlowPages.Controls.Add(reportDetails);
                CenterFlowPages.Controls.Add(forcastingDetails);


                reportDetails.Show();
                forcastingDetails.Show(); // showing the form for the graphs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SiticonePanel2_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                //timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void showUsername()
        {
            try
            {
                lblAdministrator.Text = Administrator.Current_username.ToString(); // getting the current user

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ShowNotifications()
        {
            try
            {
                string sql = conn.sqlConn();
                SqlConnection connection = new SqlConnection(sql);

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                sql = "SELECT COUNT(id) FROM Schedule;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(); // running the query

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlDataReader dataReader = cmd.ExecuteReader();


                while (dataReader.Read())
                {
                    lblTotalNofications.Text = dataReader.GetValue(0).ToString() + " Notifications...";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnContactSupplier_Click(object sender, EventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                CenterFlowPages.Controls.Clear(); // clearing all the default controls
                ContactSupplier contactSupplier = new ContactSupplier();
                contactSupplier.TopLevel = false;

                CenterFlowPages.Controls.Add(contactSupplier);
                contactSupplier.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //ShowNotifications();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
