﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wesiteApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BackBtn_Func(object sender, EventArgs e)
        {
            Response.Redirect("LoginPageForm.aspx", false);
        }
    }
}