using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLLMyLibrary;
using wesiteApp.App_Code;
namespace wesiteApp
{
    public partial class RegisterPageForm : System.Web.UI.Page
    {
        string email = string.Empty, password = string.Empty, confirmpassword = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            emailTextBox.Focus();
            errorLabel.Text = string.Empty;

        }
        public void backbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPageForm.aspx", false);
        }
        public void registerButton_Click(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
            try
            {
                email = emailTextBox.Text.Trim();
                password = passwordTextBox.Text.Trim();
                confirmpassword = confirmPasswordTextBox.Text.Trim();
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmpassword))
                {
                    errorLabel.Text = "Please enter all fields";
                    return;
                }
                string res = obj.ValidateEmail(email);
                if ((res.Equals("Invalid Email Id") || res.Equals("Input Error")))
                {
                    errorLabel.Text = "Email not valid";
                    return;
                }
                if (password.Length < 6)
                {
                    errorLabel.Text = "Password too short";
                    return;
                }
                if (!password.Equals(confirmpassword))
                {
                    errorLabel.Text = "Password and confirm password do not match";
                    return;
                }
                XMLFunctions xmlservice = new XMLFunctions();
                string hashedpassword = xmlservice.GetPassword(email);
                if (!string.IsNullOrEmpty(hashedpassword))
                {
                    errorLabel.Text = "Email already exists. Please choose a different email";
                    return;
                }
                HelperService utilityservice = new HelperService();
                hashedpassword = utilityservice.EncryptStr(password, email);
                if (!xmlservice.AddUser(email, hashedpassword))
                {
                    errorLabel.Text = "An internal error occured, please try again";
                    return;
                }
                Response.Redirect("LoginPageForm.aspx", false);
            }
            catch (Exception)
            {
            }
            Response.Redirect("LoginPageForm.aspx", false);
        }
    }
}