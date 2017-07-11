using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurrencyConvertor_TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client CurrServc = new ServiceReference2.Service1Client();
            string value = TextBox1.Text;
            string fromcurr = TextBox3.Text;
            string tocurr = TextBox4.Text;
            double tempval = double.Parse(value);
            string outp = CurrServc.CurrencyConvert(tempval, fromcurr, tocurr);
            TextBox2.Text = outp;


        }
    }
}