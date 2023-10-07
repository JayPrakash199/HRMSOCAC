﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Login.Master" CodeBehind="Default.aspx.cs" Inherits="HRMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" style="" runat="server">
    <link href="assets/vendor/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <link href="assets/vendor/css/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="assets/vendor/css/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="assets/vendor/css/common.css" rel="stylesheet" />
    <link href="assets/vendor/css/style.css" rel="stylesheet" />
    <link href="assets/vendor/css/header-style.css" rel="stylesheet" />
    <link href="assets/vendor/css/responsive.css" rel="stylesheet" />
    <link href="assets/vendor/css/font-awesome.min.css" rel="stylesheet" />
    <!--[if lt IE 9]><script src="js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="assets/vendor/js/ie-emulation-modes-warning.js"></script>

    <link href="assets/vendor/css/ch-pie-line.css" rel="stylesheet" />
    <link href="assets/vendor/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="assets/vendor/js/jsapi.js"></script>

    <link rel="stylesheet" href="assets/css/Ajaxcal.css" />
    <link rel="stylesheet" href="assets/toastr/toastr.min.css" />

    <style>
        /*Bootstrap Datepicker END!*/

        @media (min-width: 768px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (min-width: 1024px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (min-width: 1200px) {
            .bg-after-heading1 {
                display: inline-block;
            }

            .bg-after-heading {
                display: none;
            }
        }

        @media (max-width: 767px) {
            .bg-after-heading1 {
                display: none;
            }

            .bg-after-heading {
                background: #d08426;
                display: block;
            }
        }

        input#ContentPlaceHolder1_txtid {
            text-align: right;
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
            height: 36px !important;
        }

        .gradient-custom {
            /* fallback for old browsers */
            background: #6a11cb;
            /* Chrome 10-25, Safari 5.1-6 */
            background: -webkit-linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1));
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            background: linear-gradient(to right, #f8f9fa, #50b787);
        }

        .footer {
            position: absolute;
            bottom: 0;
            height: 60px;
        }

        .service-page {
            padding: 1%;
        }

        .itServicePadding {
            box-shadow: 0 4px 12px rgb(20 29 56 / 75%) !important;
            padding: 5%;
            background-color: darkslateblue;
        }

            .itServicePadding:Hover {
                background-color: #ffff;
                cursor: pointer;
                text-shadow: 2px 3px #5a5954;
            }

                .itServicePadding:Hover .content-box {
                    color: #ffff;
                }

                .itServicePadding:Hover a {
                    color: #43baff;
                }

        .icon-box-s2 {
            transition: all 0.3s linear;
            -webkit-transition: all 0.3s linear;
            -moz-transition: all 0.3s linear;
            -o-transition: all 0.3s linear;
            -ms-transition: all 0.3s linear;
        }

            .icon-box-s2.s1 .icon-main, .icon-box-s2.s3 .icon-main {
                transition: all 0.3s linear;
                -webkit-transition: all 0.3s linear;
                -moz-transition: all 0.3s linear;
                -o-transition: all 0.3s linear;
                -ms-transition: all 0.3s linear;
                float: left;
                text-align: center;
                line-height: 1;
                color: #43baff;
                padding: 5px;
            }

                .icon-box-s2.s1 .icon-main i, .icon-box-s2.s1 .icon-main span:before, .icon-box-s2.s3 .icon-main i, .icon-box-s2.s3 .icon-main span:before {
                    font-size: 45px;
                }

                .icon-box-s2.s1 .icon-main span, .icon-box-s2.s3 .icon-main span {
                    display: block;
                }

                .icon-box-s2.s1 .icon-main img, .icon-box-s2.s3 .icon-main img {
                    width: 45px;
                }

            .icon-box-s2.s1 .content-box {
                text-align: center;
            }

        .Contenta {
            text-decoration: none;
            font-size: 30px;
            font-weight: 900;
            color: #ffff;
        }

        .pb-4 {
            padding-bottom: 4%
        }
          header {
    position: unset !important;
}
    </style>
    <link rel="shortcut icon" href="images/favicon.ico" />
    <script src="assets/plugins/jQuery-lib/2.0.3/jquery.min.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/toastr/toastr.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" style="background-color: red" runat="server">

    <div class="wrapper">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnMainMenuClass" runat="server" Value="lblMainTst" />
        <asp:HiddenField ID="hdnSubMenuClass" runat="server" Value="lblTSTSub" />
        <header>
            <div class="top_header_ber">
                <div class="container">
                    <div class="pull-right current-user-name">
                        <asp:Button runat="server" ID="btnLogOut" OnClick="btnLogOut_Click" Style="background-color: #f4ecce;" CssClass="btn btnColor pull-right" Text="LogOut" />
                    </div>
                </div>
            </div>
        </header>
        <div class="gradient-custom">
            <div class="container" style="padding: 2%;">
                <div class="row">
                    <div class=" col-md-6 col-sm-6 pb-4 ">
                        <div class="icon-box-s2 s1  itServicePadding">
                            <div class="content-box">
                                <a class="Contenta" visible="false" href="Infra-MasterData.aspx" role="button" runat="server" id="btnInfraa">Infra</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4 ">
                        <div class="icon-box-s2 s1 itServicePadding">
                            <div class="content-box">
                                <a class="Contenta" visible="false" href="RecruitmentsAndRetirements.aspx" role="button" runat="server" id="btnHRMSs">HRMS</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4 ">
                        <div class="icon-box-s2 s1  itServicePadding">
                            <div class="content-box">
                                <a class="Contenta" visible="false" href="LibraryBookSearch.aspx" role="button" runat="server" id="btnLibraryMgmntt">Library Management</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6   pb-4">
                        <div class="icon-box-s2 s1  itServicePadding">
                            <div class="content-box">
                                <a class="Contenta" visible="false" href="FeeClassificationList.aspx" role="button" runat="server" id="btnFeeMgmntt">Accounts and Fee Management</a>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6 col-sm-6 pb-4" id="divreport" visible="False" runat="server">
                        <div class="icon-box-s2 s1 itServicePadding">
                            <div class="content-box">
                                <a class="Contenta" visible="True" href="ReportManagement.aspx" role="button" runat="server" id="btnReport">Report</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="btn-group btn-group-lg" role="group" aria-label="Large button group">
            </div>

        </div>

        <div>
            <asp:DropDownList Visible="False" ID="ddlCompany" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"
                Style="cursor: pointer; appearance: auto !important; width: auto" CssClass="form-control" runat="server">
            </asp:DropDownList>
            <a class="nav-link active" id="anchrCompanyName" runat="server" aria-current="page" href="#">Company Name :
                <asp:Label runat="server" ID="lblcompanyName"></asp:Label></a>
        </div>
        <div id="footer">
            <footer class="p-10">©<asp:Label runat="server" ID="Label1"></asp:Label></footer>
        </div>
    </div>


</asp:Content>
