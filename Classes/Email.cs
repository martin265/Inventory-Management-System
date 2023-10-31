using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Security;
using DGV.Utils;


namespace InventoryManagementSystem.Classes
{
    class Email
    {
        private string subject;
        private string message;
        private string email;

        public string Subject { get { return subject; } set { subject = value; } }
        public string Message { get { return message; } set { message = value; } }
        public string EmailAddres { get { return email; } set { email = value; } }
        /// <summary>
        /// the sending mail method
        /// </summary>
        public void sendEmail()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    // setting up the user credentials for sending the email address
                    Credentials = new NetworkCredential()
                    {
                        // the credentials will be here
                        UserName = "martinsilungwe12@gmail.com",
                        Password = "malamulo300"
                    }
                };

                // sending the actual message here
                MailAddress frommailAddress = new MailAddress("martinsilungwe12@gmail.com", "administrator");
                MailAddress tomailAddress = new MailAddress(email);
                MailMessage mailMessage = new MailMessage()
                {
                    From = frommailAddress,
                    Subject = subject,
                    Body = message,

                };

                mailMessage.To.Add(tomailAddress);
                try
                {
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("email message sent successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
