using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class AdditionalEmployeeDetails : System.Web.UI.Page
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
                var trades = ODataServices.GetDepartmentTradeSections(Session["SessionCompanyName"] as string);
                if (trades != null && trades.Count > 0)
                {
                    ddlTrade.DataSource = trades;
                    ddlTrade.DataTextField = "Departments_Trades_Section";
                    ddlTrade.DataValueField = "Entry_No";
                    ddlTrade.DataBind();
                    ddlTrade.Items.Insert(0, new ListItem("Select Trade", "0"));
                }

                var stations = ODataServices.GetStationList(Session["SessionCompanyName"] as string);
                if (stations != null && stations.Count > 0)
                {
                    ddlCurrentStation.DataSource = stations;
                    ddlCurrentStation.DataTextField = "Institute_Name";
                    ddlCurrentStation.DataValueField = "Institute_Code";
                    ddlCurrentStation.DataBind();
                    ddlCurrentStation.Items.Insert(0, new ListItem("Select Current Station", "0"));

                    ddlSeviceJoiningStation.DataSource = stations;
                    ddlSeviceJoiningStation.DataTextField = "Institute_Name";
                    ddlSeviceJoiningStation.DataValueField = "Institute_Code";
                    ddlSeviceJoiningStation.DataBind();
                    ddlSeviceJoiningStation.Items.Insert(0, new ListItem("Select Joining Station", "0"));
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    txtEmployeeName.Text = employeeResult.First_Name;
                }
            }
            else
            {
                if (!Convert.ToBoolean(role.Read))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to read the content. Kindly contact the system administrator.");
                    return;
                }
                var employeeResult = ODataServices.GetEmployeeInfo(txtHRMSIDSearch.Text, Session["SessionCompanyName"] as string);
                if (employeeResult != null)
                {
                    txtEmployeeName.Text = employeeResult.First_Name;
                }
            }
        }
        protected void btnAdditionalEmployeeSubmit_Click(object sender, EventArgs e)
        {
            var lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.User_Name, Helper.UserName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Page_Name.Trim(), "Add Additional Employee Details", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                AddAdditionalEmployee();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W", "You do not have permission to add the content. Kindly contact the system administrator.");
                    return;
                }
                AddAdditionalEmployee();
            }
        }

        private void AddAdditionalEmployee()
        {
            var obj = new WebServices.EmployeeAdditionalCardReference.EmployeeAdditionalInfoCard
            {
                Date_of_incrementSpecified = true,
                D_O_J_ServiceSpecified = true,
                Employment_StatusSpecified = true,
                MACP_StatusSpecified = true,
                Pension_RemarkSpecified = true,
                HRMS_ID = txtHRMSIDSearch.Text,

                //Employee_Name = txtEmployeeName.Text,
                D_O_J_Service = DateTimeParser.ParseDateTime(txtdoj.Text),
                Service_Joining_Designation = txtJoiningDesignation.Text,
                Service_Joining_Station = ddlSeviceJoiningStation.SelectedItem.Value,
                Current_Station = ddlCurrentStation.SelectedItem.Value,
                Base_Qualification = txtBaseQualification.Text,
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
                                : WebServices.EmployeeAdditionalCardReference.MACP_Status._blank_,
                Pension_Remark = ddlPensionRemark.SelectedValue == "Regular"
                    ? WebServices.EmployeeAdditionalCardReference.Pension_Remark.Regular
                    : ddlPensionRemark.SelectedValue == "NPS"
                        ? WebServices.EmployeeAdditionalCardReference.Pension_Remark.NPS
                        : WebServices.EmployeeAdditionalCardReference.Pension_Remark._blank_,
                Dept_Trade_Section = ddlTrade.SelectedItem.Text
            };
            var resultMessage = SOAPServices.AddEmployeeAdditionalInfo(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}