﻿using HRMS.Common;
using HRMSODATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using System.Configuration;
namespace HRMS
{
    public partial class ItemJournalBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindTemplate();
                //BindLocation();
                if (string.IsNullOrEmpty(Session["SessionCompanyName"] as string))
                {
                    string message = string.Format("Message: {0}\\n\\n", "Please select a company");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                    Response.Redirect("Default.aspx");
                }
            }
        }

        //private void BindTemplate()
        //{
        //    IList<HRMSODATA.ItemJournalTemplateList> itemJournalTemplateList = ODataServices.GetItemJournalTemplateList();

        //    if (itemJournalTemplateList != null)
        //    {

        //        if (itemJournalTemplateList != null && itemJournalTemplateList.Count > 0)
        //        {
        //            var lst = itemJournalTemplateList.Select(x => new
        //            {
        //                Name = x.Name,
        //                Description = x.Description
        //            }).FirstOrDefault();

        //            ddlTemplate.DataSource = itemJournalTemplateList;
        //            ddlTemplate.DataTextField = "Name";
        //            ddlTemplate.DataValueField = "Description";
        //            ddlTemplate.DataBind();
        //            ddlTemplate.Items.Insert(0, new ListItem("Select", "NA"));
        //        }


        //    }
        //}
        //private void BindTemplateBatch(String templateName)
        //{
        //    IList<HRMSODATA.ItemJournalBatches> itemJournalBatches = ODataServices.GetItemJournalBatches(templateName);


        //    if (itemJournalBatches != null && itemJournalBatches.Count > 0)
        //    {
        //        var lst = itemJournalBatches.Select(x => new
        //        {
        //            Name = x.Name,
        //            Description = x.Description
        //        });

        //        ddlBatch.DataSource = lst;
        //        ddlBatch.DataTextField = "Name";
        //        ddlBatch.DataValueField = "Description";
        //        ddlBatch.DataBind();
        //        ddlBatch.Items.Insert(0, new ListItem("Select", "NA"));
        //    }
        //    else
        //    {
        //        ddlBatch.DataSource = itemJournalBatches;
        //        ddlBatch.DataTextField = "Name";
        //        ddlBatch.DataValueField = "Description";
        //        ddlBatch.DataBind();
        //        ddlBatch.Items.Insert(0, new ListItem("Select", "NA"));
        //    }


        //}
        //private void BindLocation()
        //{
        //    IList<HRMSODATA.Locations> locationList = ODataServices.GetLocationsList();

        //    if (locationList != null)
        //    {
        //        ddllLocation.DataSource = locationList;
        //        ddllLocation.DataTextField = "Code";
        //        ddllLocation.DataValueField = "Name";
        //        ddllLocation.DataBind();
        //        ddllLocation.Items.Insert(0, new ListItem("Select", "NA"));
        //    }
        //}

        protected void btnSubmitCategory_Click(object sender, EventArgs e)
        {
            //String TemplateName = ddlTemplate.SelectedItem.Text;
            //string batchName = ddlBatch.SelectedItem.Text;
            //string location = ddllLocation.SelectedItem.Text;
            //string filePath = string.Empty;
            if (ItemFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(this.ItemFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(ItemFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;

                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    this.ItemFileUploader.SaveAs(path);
                }
                string filePath = ConfigurationManager.AppSettings["PdfPath"].ToString() + finalFileName;
                try
                {
                    SOAPServices.ItemJournalBook(filePath, Session["SessionCompanyName"] as string);
                    Alert.ShowAlert(this, "s", "Successfully completed.");
                }
                catch (Exception ex)
                {
                    string message = string.Format("Message: {0}\\n\\n", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
                }
            }

            //if (!string.IsNullOrEmpty(TemplateName) && !string.IsNullOrEmpty(batchName) && !string.IsNullOrEmpty(location))
            //{
                
            //}

        }

        //protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlTemplate.SelectedItem.Text != "Select")
        //    {
        //        BindTemplateBatch(ddlTemplate.SelectedItem.Text);
        //    }
        //}
    }
}