using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.AdminiCredentials;
using InventoryManagementSystem.Classes;
using InventoryManagementSystem.DB_connection;
using System.Data.SqlClient;



namespace InventoryManagementSystem.AdminiCredentials
{
    public partial class RegisterDetails : Form
    {
        public RegisterDetails()
        {
            InitializeComponent();
            btnLogin.Enabled = false; // making the form to be in a disabled state
        }


        Connection conn = new Connection();
        private void ChkCheckPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AdminDetailPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDetailPanel_Paint_1(object sender, PaintEventArgs e)
        {

            try
            {

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void AdminDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("please fill in the blanks first");
                }
                else
                {
                    Administrator administrator = new Administrator();

                    administrator.Username = txtUsername.Text;
                    administrator.Password = txtPassword.Text;

                    var time = DateTime.Now;
                    administrator.RegisterTime = time.ToShortTimeString();

                    var date = DateTime.Now;
                    administrator.RegisterDate = date.ToShortDateString();

                    administrator.registerAdmin();
                    clearTextBoxes();
                    btnLogin.Enabled = true;

                }
               

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearTextBoxes()
        {
            try
            {
                txtPassword.Text = "";
                txtUsername.Text = "";

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterDetails_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

           try
            {

                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("please fill in the blanks first");
                }
                else
                {
                    Administrator administrator = new Administrator();

                    administrator.Username = txtUsername.Text;
                    administrator.Password = txtPassword.Text;

                    var time = DateTime.Now;
                    administrator.RegisterTime = time.ToShortTimeString();

                    var date = DateTime.Now;
                    administrator.RegisterDate = date.ToShortDateString();

                    administrator.loginAdministrator();
                    
                    clearTextBoxes();
                    this.Hide();
                }
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
              
            
        }

        private void SiticoneRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnLogin.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
