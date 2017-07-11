using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string xmlpa = TextBox1.Text;
            string xsdpa = TextBox2.Text;
            ServiceReference1.Service1Client srvc = new ServiceReference1.Service1Client();
            string outpt = srvc.Verification_Service(xmlpa, xsdpa);
            Label4.Text = outpt;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string xmlpa = TextBox3.Text;
            string xslpa = TextBox4.Text;
            ServiceReference1.Service1Client srvc = new ServiceReference1.Service1Client();
            string ot = srvc.Transformation_Service(xmlpa, xslpa);
            TextBox5.Text = ot;
        }
    }
}