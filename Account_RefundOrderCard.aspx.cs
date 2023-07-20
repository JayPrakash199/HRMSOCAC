﻿using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_RefundOrderCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFianacialYear();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.CautionRefundOrderReference.CautionRefundOrder
            {
                Cheque_DateSpecified = true,
                Payment_MethodSpecified = true,
                Posting_DateSpecified = true,

                Academic_Year = ddlAcademicYear.SelectedItem.Text,
                Posting_Date = DateTimeParser.ParseDateTime(txtPostingDate.Text),
                Payment_Method = ddlPaymentMethod.SelectedValue == "Bank" ? WebServices.CautionRefundOrderReference.Payment_Method.Bank : WebServices.CautionRefundOrderReference.Payment_Method.Cash,
                Account_No = ddlAccountNo.SelectedValue,
                Chaque_No = txtChequeNo.Text,
                Cheque_Date = DateTimeParser.ParseDateTime(txtChequeDate.Text),
                External_Document_No = txtExternalDocumentNo.Text,
                Naration = txtNaration.Text
            };

            SOAPServices.AddCautionRefundOrder(obj, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, "s", "Record added successfully.");
        }

        public void BindFianacialYear()
        {
            int currentYear = DateTime.Today.Year;
            ddlAcademicYear.Items.Clear();
            ddlAcademicYear.Items.Add("Select");
            for (int i = 10; i >= 0; i--)
            {
                int fy = currentYear - i;
                int fy1 = fy + 1;
                if (DateTime.Now.Date > Convert.ToDateTime(fy + "-03-31").Date)
                {
                    ddlAcademicYear.Items.Add(fy.ToString() + "-" + fy1.ToString().Remove(0, 2));
                }
            }
        }

        public void GetCashAccounts()
        {            
            ddlAccountNo.DataSource = ODataServices.GetChartofAccounts(Session["SessionCompanyName"] as string);
            ddlAccountNo.DataTextField = "Name";
            ddlAccountNo.DataValueField = "No";
            ddlAccountNo.DataBind();
            ddlAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        public void GetBankAccounts()
        {
            ddlAccountNo.DataSource = ODataServices.GetBankAccountList(Session["SessionCompanyName"] as string);
            ddlAccountNo.DataTextField = "Name";
            ddlAccountNo.DataValueField = "No";
            ddlAccountNo.DataBind();
            ddlAccountNo.Items.Insert(0, new ListItem("Select Account No", "0"));
        }

        protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMethod.SelectedValue == "Bank")
            {
                GetBankAccounts();
            }
            if (ddlPaymentMethod.SelectedValue == "Cash")
            {
                GetCashAccounts();
            }
        }
    }
}