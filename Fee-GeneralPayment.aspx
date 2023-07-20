﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Fee.Master" AutoEventWireup="true" CodeBehind="Fee-GeneralPayment.aspx.cs" Inherits="HRMS.Fee_GeneralPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/material-design-icons/3.0.1/iconfont/material-icons.min.css" />
    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
            border: 1px solid;
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

        .row.md-12.marginx {
            margin: 69px;
            padding-bottom: 36px;
        }

        i.fal.fa-plus-circle.full {
            font-size: 52px;
            float: right;
            margin: 6px;
        }

        .Addaditional {
            border: solid 1px black;
            background-color: white;
            width: auto;
            height: 43px;
            margin: 10px;
            float: left;
        }

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        .form-control {
            height: 33px;
            margin: 2px 0;
            font-size: 13px;
            background-color: white;
            color: #000;
            font-weight: 700;
            border: 1px solid #7f7e7e;
        }

        select.form-control {
            background-color: white;
        }
        /*Modal Control*/
        .modal-dialog {
            width: 978px;
            margin: 30px auto;
        }

        .modal-header {
            background-color: white;
            font-size: 16px;
            line-height: 28px;
            padding: 10px 15px;
            display: inline-block;
            color: #f5f5f5;
            border-top: none;
            width: 100%;
        }

            .modalExtender-heading .close, .modal-header .close {
                margin: 6px;
            }

        .col-md-6.Buliding {
            border-bottom: 1px solid;
            padding: 20px;
        }

        h3.hadingline {
            color: black;
            font-size: 20px;
        }

        .btn-s.float-right.submit {
            background: black;
            color: white;
        }
        /*Files Button*/
        .file {
            position: relative;
            display: flex;
            justify-content: center;
            align-items: center;
        }

            .file > input[type='file'] {
                font-size: 100px;
                position: absolute;
                left: 0;
                top: 0;
                opacity: 0;
            }

            .file > label {
                font-size: 1rem;
                font-weight: 300;
                cursor: pointer;
                outline: 0;
                user-select: none;
                border-color: rgb(216, 216, 216) rgb(209, 209, 209) rgb(186, 186, 186);
                border-style: solid;
                border-radius: 4px;
                border-width: 1px;
                background-color: hsl(0, 0%, 100%);
                color: hsl(0, 0%, 29%);
                padding-left: 16px;
                padding-right: 16px;
                padding-top: 16px;
                padding-bottom: 16px;
                display: flex;
                justify-content: center;
                align-items: center;
            }

                .file > label:hover {
                    border-color: hsl(0, 0%, 21%);
                }

                .file > label:active {
                    background-color: hsl(0, 0%, 96%);
                }

                .file > label > i {
                    padding-right: 5px;
                }

            .file.float-left {
                float: left;
                margin: 16px;
            }

        .btn-upload.float-right {
            float: right;
            margin: 16px;
            width: 72px;
            height: 31px;
        }

        .btn-upload.float-left {
            float: right;
            width: auto;
            height: 31px;
        }

        .textalline {
            float: left;
            font-size: 10px;
            width: 203px;
            text-align: justify;
        }

        .inputreadonly {
            background-color: #CCC !important;
            color: #333 !important;
            border: 1px solid #666 !important;
        }

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }
    </style>
    <script type="text/javascript">
        function showLoader() {
            $('#loader').show();
        };
        function HideLoader() {
            $('#loader').hide();
        };
    </script>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-12 col-md-12 model-box">

                <div class="col-lg-12 col-md-12 summary-box">
                    <div class="col-lg-12 NewEntrydiv">
                        <p class="NewEntry">Add General Payment</p>
                    </div>
                    <div class="row">
                        <div class="card-body">
                            <div class="row md-12 marginx">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <%--<div class="form-group">
                                                    <label>Entry_No</label>
                                                    <asp:TextBox ID="txtEntry_No" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>--%>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Type</label>
                                                    <asp:DropDownList ID="ddlType" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" runat="server">
                                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                                        <asp:ListItem>Vendor</asp:ListItem>
                                                        <asp:ListItem>Caution Money</asp:ListItem>
                                                        <asp:ListItem>Employee</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group" runat="server" id="divVendorNo" visible="false">
                                                    <label for="exampleAccount">Vendor No</label>
                                                    <asp:DropDownList ID="ddlVendorNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div class="form-group" runat="server" id="divVendorName" visible="false">
                                                    <label for="exampleAccount">Vendor Name</label>
                                                    <asp:TextBox ID="txtVendorName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>--%>
                                                <div class="form-group" runat="server" id="divStudentNo" visible="false">
                                                    <label for="exampleAccount">Student No</label>
                                                    <asp:DropDownList ID="ddlStudentNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div class="form-group" runat="server" id="divStudentName" visible="false">
                                                    <label for="exampleAccount">Student Name</label>
                                                    <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>--%>
                                                <div class="form-group" runat="server" id="divEmployeeNo" visible="false">
                                                    <label for="exampleAccount">Employee No</label>
                                                    <asp:DropDownList ID="ddlEmployeeNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div class="form-group" runat="server" id="divEmployeeName" visible="false">
                                                    <label for="exampleAccount">Employee Name</label>
                                                    <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>--%>
                                                <div class="form-group">
                                                    <label for="exampleAccount">Posting Date</label>
                                                    <asp:TextBox ID="txtPostingDate" type="date" CssClass="ajax__calendar_body form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Status</label>
                                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                                        <asp:ListItem Selected="True">Open</asp:ListItem>
                                                        <asp:ListItem>Released</asp:ListItem>
                                                        <asp:ListItem>Posted</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Transaction No</label>
                                                    <asp:TextBox ID="txtCheque_No_DD" ReadOnly="True" CssClass="form-control inputreadonly" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Transaction Date</label>
                                                    <asp:TextBox ID="txtCheque_Date" ReadOnly="True" type="date" CssClass="form-control inputreadonly" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 contact-info">
                                            <div class="container">
                                                <div class="form-group">
                                                    <label>Payment Type</label>
                                                    <asp:DropDownList ID="ddlPaymentMethod" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMethod_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                                        <asp:ListItem>CASH</asp:ListItem>
                                                        <asp:ListItem>BANK</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group" runat="server" visible="false" id="divGLNo">
                                                    <label>Bank Account No</label>
                                                    <asp:DropDownList ID="ddlBank_AccountNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group" runat="server" visible="false" id="divCashGLAccount">
                                                    <label>Cash G/L Account No</label>
                                                    <asp:DropDownList ID="ddlCashAccountNo" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>External Document No</label>
                                                    <asp:TextBox ID="txtExternal_Document_No" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Amount</label>
                                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Narration</label>
                                                    <asp:TextBox ID="txtNarration" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <%--<div class="form-group">
                                                    <label>Amount LCY</label>
                                                    <asp:TextBox ID="txtAmount_LCY" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>No Series</label>
                                                    <asp:TextBox ID="txtNo_Series" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Cheque No/DD</label>
                                                    <asp:TextBox ID="txtCheque_No_DD" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Cheque Date</label>
                                                    <asp:TextBox ID="txtCheque_Date" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                
                                                <div class="form-group">
                                                    <label>UserID</label>
                                                    <asp:TextBox ID="txtUserID" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnGeneralPaymentSubmit" OnClick="btnGeneralPaymentSubmit_Click" runat="server" CssClass="btn-s float-right submit" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-2">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
