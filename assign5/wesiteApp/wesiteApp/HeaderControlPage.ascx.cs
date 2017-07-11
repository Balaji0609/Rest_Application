using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wesiteApp
{
    public partial class HeaderControlPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["email"] != null)
                {
                    emailLabel.Text = Session["email"].ToString();
                }
            }
            catch (Exception)
            {
            }

        }
        public void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");

        }
    }
}