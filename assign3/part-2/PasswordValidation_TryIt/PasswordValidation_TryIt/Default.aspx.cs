using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordValidation_TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client PassService = new ServiceReference2.Service1Client();
            string input = TextBox1.Text;
            string output = PassService.passcheck(input);
            TextBox2.Text = output;
        }
    }
}