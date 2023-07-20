using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices;

namespace HRMS
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
            {
                string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEditEmployeeSearch_Click(object sender, EventArgs e)
        {
            //var additionalEmployeeResult = ODataServices.GetAdditionalEmployeeInfo(txtHRMSIDSearch.Text);
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var roleActive = lstUserRole
                .FirstOrDefault(x => string.Equals(x.Page_Name.Trim(), "Update Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim().Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (roleActive != null && Convert.ToBoolean(roleActive.Read))
            {
                var employeeResult = ODataServices.GetAdditionalEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    txtEmployeeName.Text = employeeResult.Employee_Name;
                    ddlEmplyomentStatus.SelectedItem.Text = employeeResult.Employment_Status;
                    txtDateOfIncrement.Text = DateTimeParser.ConvertDateTimeToText(employeeResult.Date_of_increment);
                    ddlMACPStatus.SelectedItem.Text = employeeResult.MACP_Status;
                    hdnEntryNo.Value = Convert.ToString(employeeResult.Entry_No);
                    LblMessage.Text = string.Empty;
                    ddlEmplyomentStatus.Enabled = true;
                    txtDateOfIncrement.Enabled = true;
                    ddlMACPStatus.Enabled = true;
                }
                else
                {
                    txtEmployeeName.Text = string.Empty;
                    txtDateOfIncrement.Text = string.Empty;
                    LblMessage.Text = string.Empty;
                    ddlEmplyomentStatus.Enabled = false;
                    txtDateOfIncrement.Enabled = false;
                    ddlMACPStatus.Enabled = false;
                    LblMessage.Text = "No record found. Try searching with valid HRMS ID.";
                }
            }
            else
            {
                Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
            }

        }

        protected void btnEditAdditionalEmployee_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.Page_Name.Trim(), "Update Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));

            if (role == null)
            {
                EditAdditionalEmployee();
            }
            else
            {
                if (!Convert.ToBoolean(role.Modify))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to modify the content. Kindly contact the system administrator.");
                    return;
                }
                EditAdditionalEmployee();
            }
        }

        private void EditAdditionalEmployee()
        {
            if (string.IsNullOrEmpty(hdnEntryNo.Value)) return;
            var obj = new WebServices.EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard
            {
                HRMS_ID = txtHRMSIDSearch.Text,
                Entry_No = Convert.ToInt32(hdnEntryNo.Value),
                Employment_Status = ddlEmplyomentStatus.SelectedItem.Value == "Ad_hoc"
                    ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Ad_hoc
                    : ddlEmplyomentStatus.SelectedItem.Value == "Temporary_status"
                        ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Temporary_status
                        : ddlEmplyomentStatus.SelectedItem.Value == "Initial_appointee"
                            ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Initial_appointee
                            : ddlEmplyomentStatus.SelectedItem.Value == "Regular"
                                ? WebServices.EmployeeAdditionalCardReference.Employment_Status.Regular
                                : WebServices.EmployeeAdditionalCardReference.Employment_Status._blank_,
                Date_of_increment = DateTimeParser.ParseDateTime(txtDateOfIncrement.Text),
                MACP_Status = ddlMACPStatus.SelectedValue == "Nil"
                    ? WebServices.EmployeeAdditionalCardReference.MACP_Status.Nil
                    : ddlMACPStatus.SelectedValue == "1st"
                        ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0031_st
                        : ddlMACPStatus.SelectedValue == "2nd"
                            ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0032_nd
                            : ddlMACPStatus.SelectedValue == "3rd"
                                ? WebServices.EmployeeAdditionalCardReference.MACP_Status._x0033_rd
                                : WebServices.EmployeeAdditionalCardReference.MACP_Status._blank_
            };
            var resultMessage = SOAPServices.UpdateAdditionalEmployeeDetails(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.UpdateSuccessfullMessage ? "s" : "e",
                resultMessage);
        }
    }
}