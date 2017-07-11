using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wesiteApp.App_Code;
namespace wesiteApp
{
    public partial class AdminPageForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                lblErrorMessage.Visible = false;
                if (!IsPostBack)
                {
                    try
                    {
                        XMLFunctions xmlservice = new XMLFunctions();
                        List<Computer> Parts = xmlservice.GetParts();
                        foreach (Computer Part in Parts)
                        {
                            ListOfNewParts.Items.Add(new ListItem(Part.PartName + " | " + Part.price));
                        }
                        ListOfNewParts.SelectedIndex = 0;
                    }
                    catch (Exception)
                    {
                    }
                }

        }
        private void clearAll()
        {
            lblErrorMessage.Visible = false;
            txtPartPrice.Text = string.Empty;
            txtPartName.Text = string.Empty;
        }
        protected void btnClick_AddPartToCatalog(object sender, EventArgs e)
        {
            //duplicate check
            try
            {
                if (txtPartName.Text == "" || txtPartPrice.Text == "")
                {
                    //either of the text box is empty
                    lblErrorMessage.Text = "Empty values not accepted. Please enter values in textbox";
                }
                else
                {
                    Computer userPart = new Computer(txtPartName.Text,txtPartPrice.Text);
                    XMLFunctions addNewPart = new XMLFunctions();
                    if (!addNewPart.addPartsToCatalog(userPart))
                    {
                        //error happned
                        lblErrorMessage.Text = "An internal error occured. Please try again";
                        lblErrorMessage.Visible = true;
                        return;
                    }
                    ListOfNewParts.Items.Add(new ListItem(userPart.PartName + " | " + userPart.price));
                }
                lblErrorMessage.Text = "Part added to catalog Successfully";
                lblErrorMessage.Visible = true;
                //clear
                clearAll();
            }
            catch (Exception)
            {

            }
        }
        protected void btnClick_ViewPartDetails(object sender, EventArgs e)
        {
            try
            {
                List<string> partDetails = new List<string>();
                string selectedPart = ListOfNewParts.SelectedValue;
                string[] arr = selectedPart.Split('|');
                XMLFunctions getPartDetails = new XMLFunctions();
                partDetails = getPartDetails.GetPartDetails(arr[0].Trim());
                lblPartName.Text = "Part Name : " + arr[0];
                lblPartPrice.Text = "Part Price : " + partDetails[1];

            }
            catch (Exception)
            {
                lblErrorMessage.Text = "An Internal Error has occured. Please try again";
            }
        }
    }
}