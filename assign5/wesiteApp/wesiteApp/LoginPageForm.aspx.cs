using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wesiteApp
{
    public partial class LoginPageForm : System.Web.UI.Page
    {
        string email = string.Empty, password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            emailTextBox.Focus();
            errorLabel.Text = string.Empty;
            Session["email"] = null;
        }
        public void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPageForm.aspx", false);
        }
        public void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                email = emailTextBox.Text.Trim();
                password = passwordTextBox.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    errorLabel.Text = "Please enter all fields";
                    return;
                }

                App_Code.XMLFunctions xmlsrv = new App_Code.XMLFunctions();

                string hashpass = xmlsrv.GetPassword(email);

                if (string.IsNullOrEmpty(hashpass))
                {
                    errorLabel.Text = "No record found. Please register to continue";
                    return;
                }

                App_Code.HelperService hpsrv = new App_Code.HelperService();

                if (!password.Equals(hpsrv.DecryptString(hashpass)))
                {
                    errorLabel.Text = "Password does not match. Please try again";
                    return;
                }
            }
            catch(Exception ex)
            {
                App_Code.HelperService hpsrv = new App_Code.HelperService();
                hpsrv.Log(ex.Message);
                return;
            }
            if (password.Equals("Admin_123") && email.Equals("admin123@asu.edu"))
            {
                Session["email"] = email;
                Response.Redirect("AdminPageForm.aspx", false);
            }
            else
            {
                Session["email"] = email;
                Response.Redirect("UserPageForm.aspx", false);
            }
        }
    }
}