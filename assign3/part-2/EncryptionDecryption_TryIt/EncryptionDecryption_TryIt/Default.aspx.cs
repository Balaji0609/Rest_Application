using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncryptionDecryption_TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client EncryptServ = new ServiceReference2.Service1Client();
            string input = TextBox1.Text;
            string ouput = EncryptServ.Encrypt(input);
            TextBox2.Text = ouput;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client DecryptServ = new ServiceReference2.Service1Client();
            string input = TextBox3.Text;
            string output = DecryptServ.Decrypt(input);
            TextBox4.Text = output;
        }
    }
}