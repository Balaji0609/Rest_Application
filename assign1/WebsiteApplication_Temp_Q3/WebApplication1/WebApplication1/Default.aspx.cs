using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            int temp;
            bool result;
            result = int.TryParse(CInput.Text, out temp);
            if(result)
            {
                try
                {
                    Int32 C = Convert.ToInt32(CInput.Text);
                    double F = service.CtoF(C);
                    F = Math.Round(F, 1);
                    COutput.Text = F.ToString();
                }
                catch(Exception ex)
                {
                    COutput.Text = ex.Message.ToString();
                }
            }
            else
            {
                COutput.Text = "Please check on the input format";
            }
        }

        protected void Submit2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            int temp;
            bool result;
            result = int.TryParse(FInput.Text, out temp);
            if (result)
            {
                try
                {
                    Int32 F = Convert.ToInt32(FInput.Text);
                    double C = service.FtoC(F);
                    C = Math.Round(C, 1);
                    FOutput.Text = C.ToString();
                }
                catch (Exception ex)
                {
                    FOutput.Text = ex.Message.ToString();
                }
            }
            else
            {
                FOutput.Text = "Please check on the input format";
            }
        }
    }
}