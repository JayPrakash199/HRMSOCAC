﻿using HRMS.Common;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class FeeGeneration : System.Web.UI.Page
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
                var studentList = ODataServices.GetCustomerList(Session["SessionCompanyName"] as string);
                var studentListdata = from x in studentList
                                      select new
                                 {
                                     x.No,
                                     x.Name,
                                     DisplayField = String.Format("{0} ({1})", x.No, x.Name)
                                 };
                ddlStudentNo.DataSource = studentListdata;
                ddlStudentNo.DataTextField = "DisplayField";
                ddlStudentNo.DataValueField = "No";
                ddlStudentNo.DataBind();
                ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));

                var semisterList = ODataServices.GetSemisterList(Session["SessionCompanyName"] as string);
                ddlSemester.DataSource = semisterList;
                ddlSemester.DataTextField = "Description";
                ddlSemester.DataValueField = "Code";
                ddlSemester.DataBind();
                ddlSemester.Items.Insert(0, new ListItem("Select Semister", "0"));

                var courseList = ODataServices.GetCourseList(Session["SessionCompanyName"] as string);
                ddlCourseCode.DataSource = courseList;
                ddlCourseCode.DataTextField = "Description";
                ddlCourseCode.DataValueField = "Code";
                ddlCourseCode.DataBind();
                ddlCourseCode.Items.Insert(0, new ListItem("Select Course", "0"));

                var feeClassificationList = ODataServices.GetFeeClassifications(Session["SessionCompanyName"] as string);
                var feeClassificationData = from x in feeClassificationList
                                            select new
                                      {
                                          x.Code,
                                          x.Description,
                                          DisplayField = String.Format("{0} ({1})", x.Code, x.Description)
                                      };
                ddlFeeClassification.DataSource = feeClassificationData;
                ddlFeeClassification.DataTextField = "DisplayField";
                ddlFeeClassification.DataValueField = "Code";
                ddlFeeClassification.DataBind();
                ddlFeeClassification.Items.Insert(0, new ListItem("Select Fee Classification", "0"));

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var isSuccessful = false;
            if (!string.IsNullOrEmpty(Request.Form[ddlacademicYear.UniqueID]) &&
            !string.IsNullOrEmpty(ddlSemester.SelectedValue) &&
            !string.IsNullOrEmpty(ddlFeeClassification.SelectedValue) &&
                !string.IsNullOrEmpty(ddlCourseCode.SelectedValue) &&
                !string.IsNullOrEmpty(ddlStudentNo.SelectedValue))
            {
                isSuccessful = SOAPServices.GetFeeGeneration(Request.Form[ddlacademicYear.UniqueID],
                    ddlSemester.SelectedValue,
                    ddlFeeClassification.SelectedValue,
                    ddlCourseCode.SelectedValue,
                    ddlStudentNo.SelectedValue,
                    Session["SessionCompanyName"] as string);
            }
            if (isSuccessful)
                Alert.ShowAlert(this, "s", "Fee generation completed.");
            else
                Alert.ShowAlert(this, "e", "Fee generation not successful.");
        }
    }
}