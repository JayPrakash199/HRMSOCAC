﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="AERPartAList.aspx.cs" Inherits="HRMS.AERPartAList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
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
             
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Annual Establishment Review Part – A (Regular Establishment) List</p>
                    </div>
                    <div class="tab-pane active" id="1">
                        <div class="right_col_bg">
                            <div class="right_col_content border-box label-responsive">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <div id="exportto" style="height: 390px; overflow: visible">
                                                <asp:ListView ID="AnnualEstablishmentReviewListView" runat="server">
                                                    <LayoutTemplate>
                                                        <table runat="server" class="table table-bordered">
                                                            <tr class="FridgeHeader" runat="server">
                                                                <%--<th runat="server">Post Group</th>--%>
                                                                <th runat="server">Dept./Trade/Section</th>
                                                                <th runat="server">Designation</th>
                                                                <th runat="server">Employee Category</th>
                                                                <th runat="server">Pay Scale GP</th>
                                                                <th runat="server">Pay Scale 6th Pay</th>
                                                                <th runat="server">Pay Scale 7th Pay</th>
                                                                <th runat="server">Financial Year</th>
                                                                <th runat="server">Person in Position</th>
                                                                <th runat="server">Vacancy Position</th>
                                                                <th runat="server">Sanctioned Strength</th>
                                                                <th runat="server">Remark if Any</th>
                                                            </tr>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr class="TableData">
                                                            <%--<td>
                                                                <asp:Label ID="lblProjectCode" runat="server" Text='<%# Eval("Post_Group")%>'> </asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("Dept_Trade_Section")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Designation")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Employee_Catagory")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Pay_Scale_GP")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Pay_scale_6th_pay")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Pay_Scale_level_7th_pay")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Academic_Year")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Persons_in_Position")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Vacancy_Position")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Sanctioned_Strength")%>'> </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Remark")%>'> </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 ExportFoot">
                                        <asp:Button Style="margin:1%" ID="btnExport" OnClick="btnExport_Click" CssClass="exportcss btn-yellow" runat="server" Text="Export" />
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
