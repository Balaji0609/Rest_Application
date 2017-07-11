using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPage_WordFilterService
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client service = new ServiceReference2.Service1Client();
            string input = TextBox1.Text;   
            string output = service.WordfilterService(input);
            if (output != null)
                TextBox2.Text = output;
            else
                TextBox2.Text = "No input or all where stop words or tags";
        }
    }
}