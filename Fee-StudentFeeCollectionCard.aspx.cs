using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
namespace HRMS
{
    public partial class Fee_StudentFeeCollectionCard : System.Web.UI.Page
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

        public void BindCustomerList()
        {
            var studentList = ODataServices.GetCustomerList(Session["SessionCompanyName"] as string);
            var finalStudentList = new List<CommonList>();

            foreach (var student in studentList)
            {
                finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Name });
            }

            ddlCustomerNo.DataSource = finalStudentList;
            ddlCustomerNo.DataTextField = "Name";
            ddlCustomerNo.DataValueField = "No";
            ddlCustomerNo.DataBind();
            ddlCustomerNo.Items.Insert(0, new ListItem("Select Student", "0"));
        }

        public void BindFeeClassificationType()
        {
            var studentType = ODataServices.GetFeeClassificationList(Session["SessionCompanyName"] as string);
            ddlFeeClassSpecification.DataSource = studentType;
            ddlFeeClassSpecification.DataTextField = "Description";
            ddlFeeClassSpecification.DataValueField = "Code";
            ddlFeeClassSpecification.DataBind();
            ddlFeeClassSpecification.Items.Insert(0, new ListItem("Select Fee Classification", "0"));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "StudentFee")
            {
                BindCustomerList();
                divCustomerNo.Visible = true;
            }
            if (ddlType.SelectedValue == "InternalTransfer")
            {
                BindCustomerList();
                BindFeeClassificationType();
                divCustomerNo.Visible = true;
                divFeeClassiifcationType.Visible = true;
            }
            if (ddlType.SelectedValue == "AdvancePayment")
            {
                BindCustomerList();
                BindFeeClassificationType();
                divCustomerNo.Visible = true;
                divFeeClassiifcationType.Visible = true;
            }
        }

        public void GetBankAccounts()
        {
            var accounts = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in accounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlBankAccountNo.DataSource = finalAccounts;
            ddlBankAccountNo.DataTextField = "Name";
            ddlBankAccountNo.DataValueField = "No";
            ddlBankAccountNo.DataBind();
            ddlBankAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        public void GetCashAccounts()
        {
            var glAccounts = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            var finalAccounts = new List<CommonList>();
            foreach (var account in glAccounts)
            {
                finalAccounts.Add(new HRMS.CommonList { No = account.No, Name = account.No + "_" + account.Name });
            }
            ddlCashGLAccountNo.DataSource = finalAccounts;
            ddlCashGLAccountNo.DataTextField = "Name";
            ddlCashGLAccountNo.DataValueField = "No";
            ddlCashGLAccountNo.DataBind();
            ddlCashGLAccountNo.Items.Insert(0, new ListItem("Select Cash Account No", "0"));

            ddlGLNo.DataSource = finalAccounts;
            ddlGLNo.DataTextField = "Name";
            ddlGLNo.DataValueField = "No";
            ddlGLNo.DataBind();
            ddlGLNo.Items.Insert(0, new ListItem("Select Cash Account No", "0"));
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentType.SelectedValue == "BANK")
            {
                divGLNo.Visible = true;
                divBankAccountNo.Visible = true;
                divCashGLAccount.Visible = false;
                GetBankAccounts();
            }
            if (ddlPaymentType.SelectedValue == "CASH")
            {
                divCashGLAccount.Visible = true;
                divGLNo.Visible = false;
                divBankAccountNo.Visible = false;
                GetCashAccounts();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.StudentFeeCollectionReference.FeeCollection
            {
                TypeSpecified = true,
                AmountSpecified = true,
                Amount_LCYSpecified = true,
                Payment_Type_Collection_MethodSpecified = true,

                Type = ddlType.SelectedValue == "StudentFee" ? WebServices.StudentFeeCollectionReference.Type.Student_Fee
            : ddlType.SelectedValue == "OtherIncome" ? WebServices.StudentFeeCollectionReference.Type.Other_Income
            : ddlType.SelectedValue == "InternalTransfer" ? WebServices.StudentFeeCollectionReference.Type.Internal_Transfer
            : ddlType.SelectedValue == "AdvancePayment" ? WebServices.StudentFeeCollectionReference.Type.Advance_Payment
            : ddlType.SelectedValue == "StaffAdvanceRefund" ? WebServices.StudentFeeCollectionReference.Type.Staff_Advance_Refund
            : WebServices.StudentFeeCollectionReference.Type._blank_,
                Customer_No = (ddlType.SelectedValue != "OtherIncome" || ddlType.SelectedValue != "StaffAdvanceRefund") ? ddlCustomerNo.SelectedValue : string.Empty,
                //Name = (ddlType.SelectedValue != "OtherIncome" || ddlType.SelectedValue != "StaffAdvanceRefund") ? ddlCustomerNo.SelectedItem.Text.Split('_')[1]: string.Empty,
                //Grade = "",
                //Grade_Code = "",
                //Section = "",
                Fee_Class_Specification = (ddlType.SelectedValue == "InternalTransfer" || ddlType.SelectedValue == "AdvancePayment") ? ddlFeeClassSpecification.SelectedItem.Text : string.Empty,
                Amount = NumericHandler.ConvertToDecimal(txtAmount.Text),
                Amount_LCY = NumericHandler.ConvertToDecimal(txtAmountLCY.Text),
                Payment_Type_Collection_Method = ddlPaymentType.SelectedItem.Text == "CASH" ? WebServices.StudentFeeCollectionReference.Payment_Type_Collection_Method.CASH
                : ddlPaymentType.SelectedItem.Text == "BANK" ? WebServices.StudentFeeCollectionReference.Payment_Type_Collection_Method.BANK
                : WebServices.StudentFeeCollectionReference.Payment_Type_Collection_Method._blank_,
                Cash_G_L_Account_No = ddlPaymentType.SelectedValue == "CASH" ? ddlCashGLAccountNo.SelectedValue : string.Empty,
                Bank_Account_No = ddlPaymentType.SelectedValue == "BANK" ? ddlBankAccountNo.SelectedValue : string.Empty,
                Bank_Account_Name = ddlPaymentType.SelectedValue == "BANK" ? ddlBankAccountNo.SelectedItem.Text.Split('_')[1] : string.Empty,
                //Ext_Doc_No = txtExtDocNo.Text
            };

            try
            {
                SOAPServices.AddStudentFee(obj, Session["SessionCompanyName"] as string);
                Alert.ShowAlert(this, "s", "Record added successfully.");
            }
            catch (Exception ex)
            {
                Alert.ShowAlert(this, "e", ex.Message);
            }

        }
    }
}