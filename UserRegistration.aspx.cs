﻿using HRMS.Common;
using HRMS.Dto;
using InfrastructureManagement.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtMobileNo.Text))
            {
                var obj = new UserDto
                {
                    UserId = 1,
                    UserName = txtUserName.Text.Trim(),
                    Email = txtEmail.Text,
                    MobileNo = Convert.ToInt64(txtMobileNo.Text),
                    CompanyName = txtCompanyName.Text,
                    InfrastructureManagement = chkInfra.Checked,
                    HRMS = chkHRMS.Checked,
                    SLCM = chkSLCM.Checked,
                    LibraryManagement = chkLibraryManagement.Checked,
                    FeeManagement = chkFeeManagement.Checked,
                    AccountManagement = chkAccountManagement.Checked,
                    StockAndStore = chkStockAndStore.Checked,
                    Placement = chkPlacement.Checked
                };
                string apiBaseURL = ConfigurationManager.AppSettings["ExternalAPI"].ToString();

                var company = JsonConvert.SerializeObject(obj, Formatting.Indented);

                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync("User/SaveUserData", requestContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var content = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                        lbluserName.Text = txtUserName.Text;

                        if (Convert.ToString(content) != "null")
                        {
                            lblMessage.Text = "added successfully.";
                        }
                        else
                        {
                            lblMessage.Text = "already exist.";
                        }
                        toster.Visible = true;
                    }

                }
            }
        }
    }
}