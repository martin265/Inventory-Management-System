using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Windows.Forms;
using System.Net;
using System.Web.UI;
using System.IO;


namespace InventoryManagementSystem.Classes
{

    /// <summary>
    /// the class will be used to get all data using an api
    /// </summary>
    class GetApi
    {

        private string all_results;


        public string AllResults { get { return all_results; } set { all_results = value; } }
        /// <summary>
        /// method to call the api function
        /// </summary>
        public void getData()
        {
            try
            {
                string cars = string.Format("https://jsonplaceholder.typicode.com/photos"); // the variable to store the api calls for the photos
                WebRequest webRequest = WebRequest.Create(cars);

                webRequest.Method = "GET"; // using the get method to get the data
                HttpWebResponse webResponse = null;
                webResponse = (HttpWebResponse)webRequest.GetResponse(); // getting the response from the server


                string results = null;
                using (Stream stream  = webResponse.GetResponseStream())
                {
                    try
                    {

                        StreamReader streamReader = new StreamReader(stream);
                        results = streamReader.ReadToEnd();
                        all_results = results;
                        streamReader.Close();

                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
