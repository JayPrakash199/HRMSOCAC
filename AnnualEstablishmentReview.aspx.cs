using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class AnnualEstablishmentReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtAcademicYear.Text = DateTimeParser.GetCurrentAcademicYear();
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
                var trades = ODataServices.GetDepartmentTradeSections(Session["SessionCompanyName"] as string);
                if (trades != null && trades.Count > 0)
                {
                    ddlDeptTrade.DataSource = trades;
                    ddlDeptTrade.DataTextField = "Departments_Trades_Section";
                    ddlDeptTrade.DataValueField = "Entry_No";
                    ddlDeptTrade.DataBind();
                    ddlDeptTrade.Items.Insert(0, new ListItem("Select Trade", "0"));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<HRMSODATA.UserAuthorizationList> lstUserRole = ODataServices.GetUserAuthorizationList();
            var role = lstUserRole
                .FirstOrDefault(x => string.Equals(x.Page_Name.Trim(), "Part A(Regular)", StringComparison.OrdinalIgnoreCase)
                                     && string.Equals(x.Module_Name.Trim(), "HRMS", StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                InsertAnnualEstData();
            }
            else
            {
                if (!Convert.ToBoolean(role.Insert))
                {
                    Alert.ShowAlert(this, "W",
                        "You do not have permission to insert the data. Kindly contact the system administrator.");
                    return;
                }
                InsertAnnualEstData();
            }

        }

        private void InsertAnnualEstData()
        {
            var obj = new WebServices.AnnualEstablishmentReviewReference.AnnualEstablishmentReviewCard
            {
                Establishment_TypeSpecified = true,
                Post_GroupSpecified = true,
                Pay_Scale_GPSpecified = true,
                Pay_scale_6th_paySpecified = true,
                Sanctioned_StrengthSpecified = true,
                Persons_in_PositionSpecified = true,
                Employee_CatagorySpecified = true,
                Pay_Scale_level_7th_paySpecified = true,

                Establishment_Type = WebServices.AnnualEstablishmentReviewReference.Establishment_Type
                    .Part__x2013__A_Regular_Establishment,
                //Post_Group = ddlPostGroup.SelectedItem.Text == "A" ? WebServices.AnnualEstablishmentReviewReference.Post_Group.A
                //                        : ddlPostGroup.SelectedItem.Text == "C" ? WebServices.AnnualEstablishmentReviewReference.Post_Group.C
                //                        : ddlPostGroup.SelectedItem.Text == "E" ? WebServices.AnnualEstablishmentReviewReference.Post_Group.E
                //                        : WebServices.AnnualEstablishmentReviewReference.Post_Group._blank_,
                Dept_Trade_Section = ddlDeptTrade.SelectedItem.Text,
                Designation = ddlDesignation.SelectedItem.Text,
                Pay_Scale_GP = NumericHandler.ConvertToDecimal(txtPayScaleGP.Text),
                Pay_scale_6th_pay = NumericHandler.ConvertToDecimal(txtPayScale6thPay.Text),
                Sanctioned_Strength = NumericHandler.ConvertToInteger(txtSanctionedStrength.Text),

                //Persons_in_Position = NumericHandler.ConvertToInteger(txtPersonsInPosition.Text),
                Employee_Catagory = ddlCategoryofEmployee.SelectedItem.Text == "Group A"
                    ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_A
                    : ddlCategoryofEmployee.SelectedItem.Text == "Group B"
                        ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_B
                        : ddlCategoryofEmployee.SelectedItem.Text == "Group C"
                            ? WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_C
                            : WebServices.AnnualEstablishmentReviewReference.Employee_Catagory.Group_D,
                Academic_Year = ddlAcademicYear.SelectedItem.Text,
                Remark = txtRemark.Text,
                Pay_Scale_level_7th_pay = NumericHandler.ConvertToDecimal(txt7thPayScale.Text)
            };
            var resultMessage = SOAPServices.AddAnnualEstablishmentReviewRecord(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, resultMessage == ResultMessages.SuccessfullMessage ? "s" : "e", resultMessage);
        }
    }
}