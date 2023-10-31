using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using WhatsAppApi;

namespace InventoryManagementSystem.Classes
{

    /// <summary>
    /// the class to keep thye contact supplier codes
    /// </summary>
    class Contact
    {

        private int sender = 0880619483;
        private string recipient;
        private string message;
        

        public int Sender { get { return sender; } set { sender = value; } }
        public string Recipient { get { return recipient; } set { recipient = value; } }
        public string Message { get { return message; } set { message = value; } }


        public void ContactSupplier()
        {
          
        }

        
    }
}
