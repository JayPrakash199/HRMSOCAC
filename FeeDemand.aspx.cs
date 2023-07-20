﻿using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class FeeDemand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                BindStudentDropDownList();
                BindFianacialYear();
            }
        }

        public void BindStudentDropDownList()
        {
            var studentList = ODataServices.GetCustomerList(Session["SessionCompanyName"] as string);
            var finalStudentList = new List<CommonList>();

            foreach (var student in studentList)
            {
                finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Name });
            }

            ddlStudentNo.DataSource = finalStudentList;
            ddlStudentNo.DataTextField = "Name";
            ddlStudentNo.DataValueField = "No";
            ddlStudentNo.DataBind();
            ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlacademicYear.SelectedItem.Text) &&
                !string.IsNullOrEmpty(ddlStudentNo.SelectedValue) &&
                !string.IsNullOrEmpty(txtDocumentNo.Text))
            {
                var servicePath = SOAPServices.GetFeeDemand(ddlacademicYear.SelectedItem.Text,
                                                            ddlStudentNo.SelectedValue,
                                                            txtDocumentNo.Text,
                                                            Session["SessionCompanyName"] as string);
                var FileName = "Fee-Demand.pdf";
                string exportedFilePath = ConfigurationManager.AppSettings["ExportFilePath"].ToString() + StringHelper.GetFileNameFromURL(servicePath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);
                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();

            }
        }

        public void BindFianacialYear()
        {
            int currentYear = DateTime.Today.Year;
            ddlacademicYear.Items.Clear();
            ddlacademicYear.Items.Add("Select");
            for (int i = 10; i >= 0; i--)
            {
                int fy = currentYear - i;
                int fy1 = fy + 1;
                if (DateTime.Now.Date > Convert.ToDateTime(fy + "-03-31").Date)
                {
                    ddlacademicYear.Items.Add(fy.ToString() + "-" + fy1.ToString().Remove(0, 2));
                }
            }
        }
    }
}