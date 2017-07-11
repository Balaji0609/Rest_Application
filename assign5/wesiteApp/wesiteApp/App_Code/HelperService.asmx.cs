using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Net;

namespace wesiteApp.App_Code
{
    /// <summary>
    /// Summary description for HelperService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HelperService : System.Web.Services.WebService
    {
        public HelperService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        [WebMethod(Description = "Error logging")]
        public void Log(string message)
        {
            string path = Server.MapPath("~") + "\\log.txt";  //If error generated it is sent to log
            File.AppendAllText(path, "\n\n" + message); 
        }
        [WebMethod(Description = "Encrypts the message using the passphrase")]
        public string EncryptStr(string message, string passphrase)
        {
            try
            {
                EncryptDecryptWebstrar.Service1Client service = new EncryptDecryptWebstrar.Service1Client();
                string password = service.Encrypt(message);
                if (passphrase.ToLower().Contains("error"))
                {
                    return string.Empty;
                }
                return password;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [WebMethod(Description = "Decrypts the message using the passphrase")]
        public string DecryptString(string encryptedmessage)
        {
            try
            {
                EncryptDecryptWebstrar.Service1Client service = new EncryptDecryptWebstrar.Service1Client();
                string password = service.Decrypt(encryptedmessage);
                if (password.ToLower().Contains("error"))
                {
                    return string.Empty;
                }
                return password;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [WebMethod(Description = "This method is used for validating the credit card given by user.")]
        public string CreditCardValidation(string inp)
        {
            try
            {
                string url = "http://webstrar13.fulton.asu.edu/page3/Service1.svc/creditcardvalidation?Cnum=" + inp;
                var request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string ouput = reader.ReadToEnd();
                if (ouput.ToLower().Contains("invalid card number"))
                {
                    return string.Empty;
                }
                return ouput;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [WebMethod]
        public string GetVisitorCount()
        {
            string count = string.Empty;
            StreamReader sr = null;
            try
            {
                string path = Server.MapPath("App_Data/VisitorCounter.txt"); //Get the Visitor count once it is incremented for all remaining pages
                sr = new StreamReader(path);
                count = sr.ReadLine();
                if (!string.IsNullOrEmpty(count))
                {
                    return count;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                sr.Close();
            }
            return string.Empty;
        }

        [WebMethod]
        public void IncrementVisitorCount()
        {
            int count = 0;
            string path = Server.MapPath("App_Data/VisitorCounter.txt"); //Increment the visitor count
            try
            {
                string stringcount = GetVisitorCount();
                if (!string.IsNullOrEmpty(stringcount))
                {
                    count = Convert.ToInt32(stringcount) + 1;
                    string[] write = new string[1];
                    write[0] = count.ToString();
                    File.WriteAllLines(path, write);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
