using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wesiteApp.App_Code;

namespace wesiteApp
{
    public partial class UserPageForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("LoginPageForm.aspx", false);
            }
            if (!IsPostBack)
            {
                PopulateAvailableParts();
            }
            errorLabel.Text = string.Empty;

        }
        private void PopulateAvailableParts()
        {
            try
            {
                XMLFunctions xmlservice = new XMLFunctions();
                List<Computer> Parts = xmlservice.GetParts();
                foreach (Computer Part in Parts)
                {
                    availablePartsListBox.Items.Add(new ListItem(Part.PartName + " | " + Part.price));
                }
                availablePartsListBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }
        protected void addToCartButton_Click(object sender, EventArgs e)
        {
            Computer Part = null;
            try
            {
                string[] Partsall = availablePartsListBox.SelectedItem.Text.Split('|');
                Part = new Computer(Partsall[0], Partsall[1]);
                yourCartListBox.Items.Add(new ListItem(Part.PartName + " | " + Part.price,Part.PartName));
                yourCartListBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        protected void removeFromCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (yourCartListBox.Items.Count == 0)
                {
                    return;
                }
                yourCartListBox.Items.RemoveAt(yourCartListBox.SelectedIndex);
                if (yourCartListBox.Items.Count > 0)
                {
                    yourCartListBox.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void proceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            List<Computer> Parts = new List<Computer>();
            try
            {
                if (yourCartListBox.Items.Count == 0)
                {
                    errorLabel.Text = "No items to checkout";
                    return;
                }
                foreach (ListItem li in yourCartListBox.Items)
                {
                    string[] Partsall = li.Text.Split('|');
                    Parts.Add(new Computer(Partsall[0], Partsall[1]));
                }
                Session["partsincart"] = Parts;
            }
            catch (Exception)
            {
            }
            Response.Redirect("CheckOutPageForm.aspx", false);
        }
    }
}