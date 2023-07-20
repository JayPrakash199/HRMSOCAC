﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryManagement.Master" AutoEventWireup="true" CodeBehind="PostedBookAccessionList.aspx.cs" Inherits="HRMS.PostedBookAccessionList" %>

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
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <contenttemplate>

        <div class="container box">
            <div class="row">
                <div class="col-lg-3 col-md-2"></div>
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Posted Book Accession List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="PostedBookAccessionListView" runat="server">
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr runat="server">
                                                                <th runat="server">Accession_No</th>
                                                                <th runat="server">Book No</th>
                                                                <th runat="server">Unit Cost</th>
                                                                <th runat="server">Date_of_Purchase</th>
                                                                <th runat="server">Booked</th>
                                                                <th runat="server">Book_Name</th>
                                                                <%--<th runat="server">Booked_By</th>--%>
                                                                <%--<th runat="server">Advance_Booked</th>
                                                                <th runat="server">Damage/Lost Type</th>
                                                                <th runat="server">Damage/Lost By</th>--%>
                                                                <%--<th runat="server">Amount</th>--%>
                                                                <th runat="server">Condition</th>
                                                                <%--<th runat="server">Company</th>--%>
                                                                <%--<th runat="server">Book_Type</th>--%>
                                                                <th runat="server">Location_Code</th>
                                                                <%--<th runat="server">Book_Status</th>--%>
                                                                <%--<th runat="server">Bill_No</th>
                                                                <th runat="server">Bill_Date</th>
                                                                <th runat="server">MRP_Cost</th>
                                                                <th runat="server">Vendor_No</th>
                                                                <th runat="server">Remarks</th>
                                                                <th runat="server">User_ID</th>
                                                                <th runat="server">Portal_ID</th>
                                                                <th runat="server">Currencies</th>--%>
                                                                <th runat="server">Book_Source</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">    
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Accession_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Book_No")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Unit_Cost")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" Text='<%# DateTime.Parse(Eval("Date_of_Purchase").ToString()).ToString("d") %>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Booked")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Book_Name")%>'> </asp:Label>
                                                            </td>
                                                            <%--<td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Booked_By")%>'> </asp:Label>
                                                            </td>--%>
                                                            <%--<td>
                                                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("Advance_Booked")%>'> </asp:Label>
                                                            </td>--%>
                                                            <%--<td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Damage_Lost_Type")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Damaged_Lost_By")%>'> </asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Condition")%>'> </asp:Label>
                                                            </td>
                                                            <%--<td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Company")%>'> </asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Location_Code")%>'> </asp:Label>
                                                            </td>
                                                            <%--<td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Book_Status")%>'> </asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("Book_Source")%>'> </asp:Label>
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
    </contenttemplate>
</asp:Content>