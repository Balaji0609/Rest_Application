using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wesiteApp.App_Code;
using DLLMyLibrary;

namespace wesiteApp
{
    public partial class CheckOutPageForm : System.Web.UI.Page
    {
        List<Computer> Parts = new List<Computer>();
        decimal totalamount;
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            if (Session["email"] == null)
            {
                Response.Redirect("LoginPageForm.aspx", false);
            }

            try
            {
                if (!IsPostBack)
                {

                    if (Session["partsincart"] != null)
                    {
                        Parts = (List<Computer>)Session["partsincart"];
                        foreach (Computer part in Parts)
                        {
                            yourCartListBox.Items.Add(new ListItem(part.PartName + " | " + part.price));
                            totalamount += Convert.ToDecimal(part.price.Split('$')[1]);
                        }
                        totalAmountTextBox.Text = totalamount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                HelperService service = new HelperService();
                service.Log(ex.Message);
            }
        }

        protected void creditCardTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HelperService utilityservice = new HelperService();
                string status = utilityservice.CreditCardValidation(creditCardTextBox.Text.Trim());

                if (string.IsNullOrEmpty(status))
                {
                    errorLabel.Text = "Invalid credit card number";
                    return;
                }
            }
            catch (Exception ex)
            {
                HelperService service = new HelperService();
                service.Log(ex.Message);
            }
        }


        protected void confirmButton_Click(object sender, EventArgs e)
        {
            Class1 validateobj = new Class1();
            try
            {
                if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(creditCardTextBox.Text) || string.IsNullOrEmpty(expiryDateTextBox.Text) ||
                    string.IsNullOrEmpty(zipTextBox.Text) || string.IsNullOrEmpty(phoneTextBox.Text))
                {
                    errorLabel.Text = "Please enter all fields";
                    return;
                }

                string phstr = validateobj.ValidatePhone(phoneTextBox.Text);
                if ((phstr == "Invalid US Phone Number" || phstr == "Input Error"))
                {
                    errorLabel.Text = "Invalid phone";
                    return;
                }
                HelperService utilityservice = new HelperService();
                if (string.IsNullOrEmpty(utilityservice.CreditCardValidation(creditCardTextBox.Text)))
                {
                    errorLabel.Text = "Invalid credit card number";
                    return;
                }
                string zipstr = validateobj.ValidateZip(zipTextBox.Text);
                if ((zipstr == "Invalid US Zip Code" || zipstr == "Input Error"))
                {
                    errorLabel.Text = "Invalid zip";
                    return;
                }
                try
                {
                    System.DateTime dt = Convert.ToDateTime(expiryDateTextBox.Text.Trim());
                    if (dt <= System.DateTime.Now)
                    {
                        errorLabel.Text = "Invalid date";
                        return;
                    }
                }
                catch (Exception)
                {
                    errorLabel.Text = "Invalid date";
                    return;
                }

                Response.Redirect("WebForm1.aspx", false);
            }
            catch (Exception ex)
            {
                HelperService service = new HelperService();
                service.Log(ex.Message);
            }
        }
    }
}