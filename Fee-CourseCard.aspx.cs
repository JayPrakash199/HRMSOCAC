using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class Fee_CourseCard : System.Web.UI.Page
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
                var studentType = ODataServices.GetFeeClassificationList(Session["SessionCompanyName"] as string);
                ddlFeeClassification.DataSource = studentType;
                ddlFeeClassification.DataTextField = "Description";
                ddlFeeClassification.DataValueField = "Code";
                ddlFeeClassification.DataBind();
                ddlFeeClassification.Items.Insert(0, new ListItem("Select Fee Classification", "0"));

                var semisterList = ODataServices.GetSemisterList(Session["SessionCompanyName"] as string);
                ddlSemester.DataSource = semisterList;
                ddlSemester.DataTextField = "Description";
                ddlSemester.DataValueField = "Code";
                ddlSemester.DataBind();
                ddlSemester.Items.Insert(0, new ListItem("Select Semister", "0"));

                var courses = ODataServices.GetCourseList(Session["SessionCompanyName"] as string);
                ddlProgramCode.DataSource = semisterList;
                ddlProgramCode.DataTextField = "Code";
                ddlProgramCode.DataBind();
                ddlProgramCode.Items.Insert(0, new ListItem("Select Course Code", "0"));

                var number = Request.QueryString["No"];
                if (!string.IsNullOrEmpty(number))
                {
                    var courseFeeHeader = ODataServices.GetCourseFeeHeaderList(Session["SessionCompanyName"] as string)
                        .Where(x => String.Equals(x.No, number, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (courseFeeHeader != null)
                    {
                        txtNo.Text = courseFeeHeader.No;
                        ddlGraduation.SelectedValue = courseFeeHeader.Branch;
                        ddlProgramCode.SelectedValue = courseFeeHeader.Program_Code;
                        txtProgramName.Text = courseFeeHeader.Program_Name;
                        ddlYear.SelectedValue = courseFeeHeader.Year;
                        txtAdmittedYear.Text = courseFeeHeader.Admitted_Year;
                        txtAcademicYear.Text = courseFeeHeader.Academic_Year;
                        ddlFeeClassification.SelectedValue = courseFeeHeader.Fee_Classification;
                        //txtInstituteCode.Text = courseFeeHeader.Program_Code;
                        //txtDepartmentCode.Text = courseFeeHeader.Program_Code;
                        txtTotalAmount.Text = Convert.ToString(courseFeeHeader.Total_Amount);
                        //ddlStatus.SelectedValue = courseFeeHeader.;
                    }
                }
                var feeLine = ODataServices.GetCourseFeeLines(Session["SessionCompanyName"] as string).Where(x => String.Equals(x.Document_No, number, StringComparison.OrdinalIgnoreCase));
                if (feeLine != null)
                {
                    CourseFeeLineListView.DataSource = feeLine;
                    CourseFeeLineListView.DataBind();
                }
            }
        }
    }
}