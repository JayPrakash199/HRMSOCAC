﻿using HRMS.Common;
using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace HRMS
{
    public partial class LibraryBookSearch : System.Web.UI.Page
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
                BindListView();
            }
        }

        private void BindListView()
        {
            var LibrarySearchList = ODataServices.GetBookList(Session["SessionCompanyName"] as string);
            if (LibrarySearchList != null)
            {
                LibrarySearchListView.DataSource = LibrarySearchList;
                LibrarySearchListView.DataBind();
            }
        }


        protected void LibrarySearchListView_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            BindPublisherDropdown();
            BindBookcatagoryDropdown();
            BindLanguageDropDown();
            BindLocationDropDown();
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#MyPopup').modal('show')", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showLoader();", true);
            string slNo = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblNo") as Label).Text;
            string BookName = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblBookName") as Label).Text;
            string AuthorName = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblAuthorName") as Label).Text;
            string aName = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblAuthorName2") as Label).Text;
            string PublisherCode = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblPublisherName") as Label).Text;
            string bookCategory = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblCategory") as Label).Text;
            string language = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblLanguage") as Label).Text;
            string locationCode = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblLocationCode") as Label).Text;
            string bookType = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblBookType") as Label).Text;
            string noOfPages = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblNoOfPages") as Label).Text;
            string callNo = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblCallNo") as Label).Text;
            string shelf = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblShelf") as Label).Text;
            string supplierName = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblSupplierName") as Label).Text;
            string unitCost = (LibrarySearchListView.Items[e.NewEditIndex].FindControl("lblUnit_Cost") as Label).Text;


            if (!string.IsNullOrEmpty(PublisherCode))
            {
                ddlPublisherCode.SelectedValue = PublisherCode;
                var list= ddlPublisherCode.DataSource as List<HRMSODATA.PublisherName>;
                txtPublisherName.Text = list.Where(x => x.Code == PublisherCode).Select(s => s.Description).FirstOrDefault().ToString();
            }
            if (!string.IsNullOrEmpty(bookCategory) && bookCategory != "0")
            {
                ddlBookcategoryCode.SelectedValue = bookCategory;
            }
            if (!string.IsNullOrEmpty(language))
            {
                ddllanguage.SelectedValue = language;
            }
            if (!string.IsNullOrEmpty(locationCode))
            {
                ddlLocationCode.SelectedValue = locationCode;
            }
            if (!string.IsNullOrEmpty(bookType) && bookCategory != "0")
            {
                ddlBookType.SelectedValue = bookType;
            }

            txtCallNo.Text = callNo;
            txtShelf.Text = shelf;
            txtSuplierName.Text = supplierName;
            txtNoOfpages.Text = noOfPages;
            txtmdBookName.Text = BookName;
            txtmdAuthorName.Text = AuthorName;
            txtmdAuthorName2.Text = aName;
            txtno.Text = slNo;
            txtUnitCost.Text = unitCost;

            //BindBookTypeDropDown();
        }

        protected void LibrarySearchListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LibrarySearchListView.EditIndex = -1;
            BindListView();
        }

        protected void btnLibraryBookSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbookSearch.Text))
            {
                var LibrarySearchList = ODataServices.GetFilterBookList(txtbookSearch.Text, Session["SessionCompanyName"] as string);
                if (LibrarySearchList != null)
                {
                    LibrarySearchListView.DataSource = LibrarySearchList;
                    LibrarySearchListView.DataBind();
                }
            }
            else
            {
                var LibraryList = ODataServices.GetBookList(Session["SessionCompanyName"] as string);
                if (LibraryList != null)
                {
                    LibrarySearchListView.DataSource = LibraryList;
                    LibrarySearchListView.DataBind();
                }
            }

        }

        private void showPopup(string title, string body)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

        private void BindPublisherDropdown()
        {
            var list = ODataServices.GetPublisherNames(Session["SessionCompanyName"] as string);
            ddlPublisherCode.DataSource = list;
            ddlPublisherCode.DataTextField = "Code";
            ddlPublisherCode.DataValueField = "Code";
            ddlPublisherCode.DataBind();
            ddlPublisherCode.Items.Insert(0, new ListItem("Select", "NA"));

            
        }
        private void BindBookcatagoryDropdown()
        {
            ddlBookcategoryCode.DataSource = ODataServices.GetBookCategoryList(Session["SessionCompanyName"] as string);
            ddlBookcategoryCode.DataTextField = "Code";
            ddlBookcategoryCode.DataValueField = "Code";
            ddlBookcategoryCode.DataBind();
            ddlBookcategoryCode.Items.Insert(0, new ListItem("Select", "NA"));
        }
        private void BindLanguageDropDown()
        {
            ddllanguage.DataSource = ODataServices.GetLanguageList(Session["SessionCompanyName"] as string);
            ddllanguage.DataTextField = "Code";
            ddllanguage.DataValueField = "Code";
            ddllanguage.DataBind();
            ddllanguage.Items.Insert(0, new ListItem("Select", "NA"));
        }
        private void BindLocationDropDown()
        {
            ddlLocationCode.DataSource = ODataServices.GetLocationsList(Session["SessionCompanyName"] as string);
            ddlLocationCode.DataTextField = "Code";
            ddlLocationCode.DataValueField = "Code";
            ddlLocationCode.DataBind();
            ddlLocationCode.Items.Insert(0, new ListItem("Select", "NA"));
        }
        private void BindBookTypeDropDown()
        {
            //ddlBookType.DataSource = ODataServices.GetBookTypes(Session["SessionCompanyName"] as string);
            //List<string> bookType = new List<string> {"Hindi Fiction","English Fiction","Reference Books","Text Books","Subject Books" }; 
            //ddlBookType.DataTextField = "Code";
            //ddlBookType.DataValueField = "Code";
            //ddlBookType.DataBind();
            //ddlBookType.Items.Insert(0, new ListItem("Select", "NA"));
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string BookName = txtmdBookName.Text;
            string AuthorName = txtmdAuthorName.Text;
            string AuthorName_2 = txtmdAuthorName2.Text;
            string PublisherName = ddlPublisherCode.SelectedItem.Text == "Select" ? "" : ddlPublisherCode.SelectedItem.Text;
            string Bookcategorycode = ddlBookcategoryCode.SelectedItem.Text == "Select" ? "" : ddlBookcategoryCode.SelectedItem.Text;
            string NoofPages = txtNoOfpages.Text;
            bool NoOfPageSpecified = !string.IsNullOrEmpty(NoofPages) ? true : false;
            string callNo = txtCallNo.Text;
            string shelf = txtShelf.Text;
            string Language = ddllanguage.SelectedItem.Text == "Select" ? "" : ddllanguage.SelectedItem.Text;
            string locationCode = ddlLocationCode.SelectedItem.Text == "Select" ? "" : ddlLocationCode.SelectedItem.Text;
            String bookType = ddlBookType.SelectedItem.Text == "Select" ? "" : ddlBookType.SelectedValue;
            decimal unitCost = NumericHandler.ConvertToDecimal(txtUnitCost.Text);
            var SuplierName = txtSuplierName.Text;
            var updateObj = new WebServices.BookCardReference1.BookCard
            {
                No = txtno.Text,
                Book_Name = BookName,
                Author_Name = AuthorName,
                Author_Name_2 = AuthorName_2,
                Place__Publisher_Name = PublisherName,
                Book_Category_Code = NumericHandler.ConvertToDecimal(Bookcategorycode),
                No_of_Pages = NumericHandler.ConvertToInteger(NoofPages),
                No_of_PagesSpecified = NoOfPageSpecified,
                Call_No = callNo,
                Shelf = shelf,
                Langauge = Language,
                Book_Type = bookType == "HindiFiction" ? WebServices.BookCardReference1.Book_Type.Hindi_Fiction
                : bookType == "EnglishFiction" ? WebServices.BookCardReference1.Book_Type.English_Fiction
                : bookType == "ReferenceBooks" ? WebServices.BookCardReference1.Book_Type.Reference_Books
                : bookType == "TextBooks" ? WebServices.BookCardReference1.Book_Type.Text_Books
                : bookType == "SubjectBooks" ? WebServices.BookCardReference1.Book_Type.Subject_Books
                : WebServices.BookCardReference1.Book_Type._blank_,
                Supplier_Name = SuplierName,
                Location_Code11039 = locationCode,
                Unit_Cost = unitCost
            };

            var result = SOAPServices.UpdateBookDetails(updateObj, Session["SessionCompanyName"] as string);
            if (result == ResultMessages.UpdateSuccessfullMessage)
            {
                Alert.ShowAlert(this, "s", "Book updated successfully.");
            }
            else
            {
                Alert.ShowAlert(this, "e", "Update unsuccessfull.");
            }
            BindListView();
        }


        protected void btnAccession_Click(object sender, EventArgs e)
        {
            try
            {
                SOAPServices.AddBookToAccessionList(txtno.Text, Session["SessionCompanyName"] as string);
                Response.Redirect("BookAccessionList.aspx");
            }
            catch (Exception ex)
            {
                string message = string.Format("Message: {0}\\n\\n", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            }

        }

        protected void ddlPublisherCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = ddlPublisherCode.DataSource as List<HRMSODATA.PublisherName>;
            txtPublisherName.Text = list.Where(x => x.Code == ddlPublisherCode.SelectedValue).Select(s=> s.Description).FirstOrDefault().ToString();

        }
    }
}