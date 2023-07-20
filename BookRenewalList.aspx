﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryManagement.Master" AutoEventWireup="true" CodeBehind="BookRenewalList.aspx.cs" Inherits="HRMS.BookRenewalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        table thead tr th, .table > tbody > tr > th {
            border-top: none !important;
        }

        .container.box {
            margin-top: 61px;
            margin-bottom: 26px;
        }

        p.NewEntry {
            float: left;
            font-weight: 600;
            color: black;
        }

        .col-lg-12.NewEntrydiv {
            background-color: #eeeeee;
        }

        p.Introduction {
            float: left;
            color: black;
            padding: 23px;
            text-transform: uppercase;
            font-weight: 700;
        }

        .right_col_content.border-box.label-responsive {
            border: none;
        }

        .exportcss {
            float: left;
            border: solid 1px black;
            background-color: white;
        }

        .printcss {
            float: right;
            border: solid 1px black;
            background-color: white;
        }

        i.fa-solid.fa-file {
            font-size: 35px;
        }

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }

        .custom-file-input::-webkit-file-upload-button {
            visibility: hidden;
        }

        .custom-file-input::before {
            content: 'Choose File';
            display: inline-block;
            background: linear-gradient(top, #f9f9f9, #e3e3e3);
            border: 1px solid #999;
            border-radius: 3px;
            padding: 5px 8px;
            outline: none;
            white-space: nowrap;
            -webkit-user-select: none;
            cursor: pointer;
            text-shadow: 1px 1px #fff;
            font-weight: 700;
            font-size: 10pt;
        }

        .custom-file-input:hover::before {
            border-color: black;
        }

        .custom-file-input:active::before {
            background: -webkit-linear-gradient(top, #e3e3e3, #f9f9f9);
        }

        i.fa.fa-search.icon {
            position: absolute;
            padding: 10px;
            display: block;
        }

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        input#ContentPlaceHolder1_txtbookRenewalSearch {
            text-align: right;
        }
        
    </style>
   
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>
        <div class="messagealert" id="alert_container"></div>
        <div class="container box">
            <div class="row">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Book Renewal List</p>
                    </div>

                    <div class="col-lg-12" style="padding: 15px">
                        <div class="container">
                            <div class="form-group">
                                <div class="col-md-3" style="padding-left: 0px;">
                                    <i class="fa fa-search icon"></i>
                                    <asp:TextBox ID="txtbookRenewalSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearchBookRenewaldata" OnClientClick="showLoader();" OnClick="btnSearchBookRenewaldata_Click" CssClass="btn-s float-right submit btn-yellow form-control" Text="Search" runat="server" />
                                </div>
                                <div class="col-md-7" style="padding-top: 0.5%;">
                                    <asp:Label CssClass="message" ID="LblMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="BookRenewalListView" runat="server" OnItemCommand="BookReturnListView_ItemCommand">
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Entry No</th>
                                                                <th runat="server">Type</th>
                                                                <th runat="server">No</th>
                                                                <th runat="server">Name</th>
                                                                <th runat="server">Accession No</th>
                                                                <th runat="server">Book No</th>
                                                                <th runat="server">Book Name</th>
                                                                <th runat="server">Date of Issue</th>
                                                                <th runat="server">Date of Return</th>
                                                                <th runat="server">Action</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <td>
                                                                <asp:Label ID="lblEntry_No" runat="server" Text='<%# Eval("Entry_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUser_Type" runat="server" Text='<%# Eval("User_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAccession_No" runat="server" Text='<%# Eval("Accession_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBook_No" runat="server" Text='<%# Eval("Book_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBook_Name" runat="server" Text='<%# Eval("Book_Name")%>'> </asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="lblDate_of_Issue" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_Issue").ToString()).ToString("d") %>'>  </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDate_of_Return" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_Return").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnRenewal" CssClass="exportcss btn" runat="server" Text='Renewal' CommandArgument='<%#Eval("Entry_No")%>' CommandName="Renewal" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
