﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Account_RefundOrderCard.aspx.cs" Inherits="HRMS.Account_RefundOrderCard" %>
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
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">
                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Caution Refund Order Card</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label for="exampleAccount">Academic Year</label>
                                                    <asp:DropDownList ID="ddlAcademicYear" CssClass="form-control ajax__calendar_body" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                               <div class="form-group">
                                                    <label>Posting Date</label>
                                                    <asp:TextBox ID="txtPostingDate" type="date" CssClass="form-control ajax__calendar_body" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Payment Method</label>
                                                    <asp:DropDownList ID="ddlPaymentMethod" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMethod_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                                        <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Account No</label>
                                                    <asp:DropDownList ID="ddlAccountNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label>Cheque No</label>
                                                    <asp:TextBox ID="txtChequeNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                               <div class="form-group">
                                                    <label>Cheque Date</label>
                                                    <asp:TextBox ID="txtChequeDate" type="date" CssClass="ajax__calendar_body form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>External Document No</label>
                                                    <asp:TextBox ID="txtExternalDocumentNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Naration</label>
                                                    <asp:TextBox ID="txtNaration" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn-s float-right btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
