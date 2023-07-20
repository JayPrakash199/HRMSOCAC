﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfrastructureManagement
{
    public partial class DefaultMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCompanyName.Text = System.Web.HttpUtility.UrlDecode(Convert.ToString(Session["SessionCompanyName"]));
                var userobj = Session["UserData"] as string;
                if (!string.IsNullOrEmpty(userobj))
                {
                    var userData = JObject.Parse(userobj.ToString());
                    var isHRMS = Convert.ToBoolean(userData["HRMS"]);
                    if (!isHRMS)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}