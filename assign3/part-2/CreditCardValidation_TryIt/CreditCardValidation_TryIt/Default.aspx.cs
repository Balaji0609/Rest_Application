using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.ServiceModel;
using System.Web.UI.WebControls;

namespace CreditCardValidation_TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string inp = TextBox1.Text;
                string url = "http://webstrar13.fulton.asu.edu/page3/Service1.svc/creditcardvalidation?Cnum="+ inp;
                var request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string ouput = reader.ReadToEnd();
                //ServiceReference1.Service1Client Cardserv = new ServiceReference1.Service1Client();
                //string outp = Cardserv.creditcardvalidation(inp);
                Label3.Text = ouput;
            }
            catch(Exception ex)
            {
                Label3.Text = ex.Message;
            }
        }
    }
}