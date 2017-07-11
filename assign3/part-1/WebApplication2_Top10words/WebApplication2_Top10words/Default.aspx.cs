using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2_Top10words
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client service = new ServiceReference2.Service1Client();
            string temp = TextBox1.Text;
            string [] array;
            string output = "";
            string s;
            if(String.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox1.Text = "The text box is empty give the url";
            }
            else
            {
                array = service.Top10WordsService(temp);
                for(int i = 0; i < 10; i++)
                {
                    s = array[i];
                    output += "\"" + s + "\"";
                }
                TextBox2.Text = output;
            }
        }
    }
}