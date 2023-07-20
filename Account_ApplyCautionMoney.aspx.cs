using HRMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Account_ApplyCautionMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var studentList = ODataServices.GetStudentList(Session["SessionCompanyName"] as string);
                var finalStudentList = new List<CommonList>();
                foreach (var student in studentList)
                {
                    finalStudentList.Add(new HRMS.CommonList { No = student.No, Name = student.No + "_" + student.Student_Name });
                }
                ddlStudentNo.DataSource = finalStudentList;
                ddlStudentNo.DataTextField = "Name";
                ddlStudentNo.DataValueField = "No";
                ddlStudentNo.DataBind();
                ddlStudentNo.Items.Insert(0, new ListItem("Select Student", "0"));
                BindFianacialYear();
            }
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
                    ddlAcademicYear.Items.Add(fy.ToString() + "-" + fy1.ToString().Remove(0,2));
                }
            }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SOAPServices.ApplyCautionMoney(ddlStudentNo.SelectedValue, ddlAcademicYear.SelectedItem.Text, Session["SessionCompanyName"] as string);
            Alert.ShowAlert(this, "s", "Applied successfully.");
        }
    }

    public class CommonList
    {
        public string No { get; set; }
        public string Name { get; set; }
    }
}