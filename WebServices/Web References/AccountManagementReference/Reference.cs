﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WebServices.AccountManagementReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AccountManagement_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement")]
    public partial class AccountManagement : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback DeleteCautionRefundLineOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetLinesOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostToJournalOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostedCautionMoneyReportOperationCompleted;
        
        private System.Threading.SendOrPostCallback SubMitCautionMoneyOperationCompleted;
        
        private System.Threading.SendOrPostCallback UnpostedCautionMoneyReportOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AccountManagement() {
            this.Url = global::WebServices.Properties.Settings.Default.WebServices_AccountManagementReference_AccountManagement;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event DeleteCautionRefundLineCompletedEventHandler DeleteCautionRefundLineCompleted;
        
        /// <remarks/>
        public event GetLinesCompletedEventHandler GetLinesCompleted;
        
        /// <remarks/>
        public event PostToJournalCompletedEventHandler PostToJournalCompleted;
        
        /// <remarks/>
        public event PostedCautionMoneyReportCompletedEventHandler PostedCautionMoneyReportCompleted;
        
        /// <remarks/>
        public event SubMitCautionMoneyCompletedEventHandler SubMitCautionMoneyCompleted;
        
        /// <remarks/>
        public event UnpostedCautionMoneyReportCompletedEventHandler UnpostedCautionMoneyReportCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:DeleteCautionRefundLine" +
            "", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="DeleteCautionRefundLine_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public bool DeleteCautionRefundLine(string refundSlNo, int lineNo) {
            object[] results = this.Invoke("DeleteCautionRefundLine", new object[] {
                        refundSlNo,
                        lineNo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteCautionRefundLineAsync(string refundSlNo, int lineNo) {
            this.DeleteCautionRefundLineAsync(refundSlNo, lineNo, null);
        }
        
        /// <remarks/>
        public void DeleteCautionRefundLineAsync(string refundSlNo, int lineNo, object userState) {
            if ((this.DeleteCautionRefundLineOperationCompleted == null)) {
                this.DeleteCautionRefundLineOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteCautionRefundLineOperationCompleted);
            }
            this.InvokeAsync("DeleteCautionRefundLine", new object[] {
                        refundSlNo,
                        lineNo}, this.DeleteCautionRefundLineOperationCompleted, userState);
        }
        
        private void OnDeleteCautionRefundLineOperationCompleted(object arg) {
            if ((this.DeleteCautionRefundLineCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCautionRefundLineCompleted(this, new DeleteCautionRefundLineCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:GetLines", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="GetLines_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetLines(string academicYear, string refundSlNo) {
            this.Invoke("GetLines", new object[] {
                        academicYear,
                        refundSlNo});
        }
        
        /// <remarks/>
        public void GetLinesAsync(string academicYear, string refundSlNo) {
            this.GetLinesAsync(academicYear, refundSlNo, null);
        }
        
        /// <remarks/>
        public void GetLinesAsync(string academicYear, string refundSlNo, object userState) {
            if ((this.GetLinesOperationCompleted == null)) {
                this.GetLinesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLinesOperationCompleted);
            }
            this.InvokeAsync("GetLines", new object[] {
                        academicYear,
                        refundSlNo}, this.GetLinesOperationCompleted, userState);
        }
        
        private void OnGetLinesOperationCompleted(object arg) {
            if ((this.GetLinesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLinesCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:PostToJournal", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="PostToJournal_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void PostToJournal(bool posted, string refundSlNo, string externalDocNo, [System.Xml.Serialization.XmlElementAttribute(DataType="date")] System.DateTime postingDate, string narration, int paymentMethod, string accountNo, string chequeNo, [System.Xml.Serialization.XmlElementAttribute(DataType="date")] System.DateTime chequeDate) {
            this.Invoke("PostToJournal", new object[] {
                        posted,
                        refundSlNo,
                        externalDocNo,
                        postingDate,
                        narration,
                        paymentMethod,
                        accountNo,
                        chequeNo,
                        chequeDate});
        }
        
        /// <remarks/>
        public void PostToJournalAsync(bool posted, string refundSlNo, string externalDocNo, System.DateTime postingDate, string narration, int paymentMethod, string accountNo, string chequeNo, System.DateTime chequeDate) {
            this.PostToJournalAsync(posted, refundSlNo, externalDocNo, postingDate, narration, paymentMethod, accountNo, chequeNo, chequeDate, null);
        }
        
        /// <remarks/>
        public void PostToJournalAsync(bool posted, string refundSlNo, string externalDocNo, System.DateTime postingDate, string narration, int paymentMethod, string accountNo, string chequeNo, System.DateTime chequeDate, object userState) {
            if ((this.PostToJournalOperationCompleted == null)) {
                this.PostToJournalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostToJournalOperationCompleted);
            }
            this.InvokeAsync("PostToJournal", new object[] {
                        posted,
                        refundSlNo,
                        externalDocNo,
                        postingDate,
                        narration,
                        paymentMethod,
                        accountNo,
                        chequeNo,
                        chequeDate}, this.PostToJournalOperationCompleted, userState);
        }
        
        private void OnPostToJournalOperationCompleted(object arg) {
            if ((this.PostToJournalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostToJournalCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:PostedCautionMoneyRepor" +
            "t", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="PostedCautionMoneyReport_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string PostedCautionMoneyReport(string refundSlNo) {
            object[] results = this.Invoke("PostedCautionMoneyReport", new object[] {
                        refundSlNo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PostedCautionMoneyReportAsync(string refundSlNo) {
            this.PostedCautionMoneyReportAsync(refundSlNo, null);
        }
        
        /// <remarks/>
        public void PostedCautionMoneyReportAsync(string refundSlNo, object userState) {
            if ((this.PostedCautionMoneyReportOperationCompleted == null)) {
                this.PostedCautionMoneyReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostedCautionMoneyReportOperationCompleted);
            }
            this.InvokeAsync("PostedCautionMoneyReport", new object[] {
                        refundSlNo}, this.PostedCautionMoneyReportOperationCompleted, userState);
        }
        
        private void OnPostedCautionMoneyReportOperationCompleted(object arg) {
            if ((this.PostedCautionMoneyReportCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostedCautionMoneyReportCompleted(this, new PostedCautionMoneyReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:SubMitCautionMoney", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="SubMitCautionMoney_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SubMitCautionMoney(string studentNo, string academicYear) {
            this.Invoke("SubMitCautionMoney", new object[] {
                        studentNo,
                        academicYear});
        }
        
        /// <remarks/>
        public void SubMitCautionMoneyAsync(string studentNo, string academicYear) {
            this.SubMitCautionMoneyAsync(studentNo, academicYear, null);
        }
        
        /// <remarks/>
        public void SubMitCautionMoneyAsync(string studentNo, string academicYear, object userState) {
            if ((this.SubMitCautionMoneyOperationCompleted == null)) {
                this.SubMitCautionMoneyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubMitCautionMoneyOperationCompleted);
            }
            this.InvokeAsync("SubMitCautionMoney", new object[] {
                        studentNo,
                        academicYear}, this.SubMitCautionMoneyOperationCompleted, userState);
        }
        
        private void OnSubMitCautionMoneyOperationCompleted(object arg) {
            if ((this.SubMitCautionMoneyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubMitCautionMoneyCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/AccountManagement:UnpostedCautionMoneyRep" +
            "ort", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", ResponseElementName="UnpostedCautionMoneyReport_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/AccountManagement", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string UnpostedCautionMoneyReport(string refundSlNo) {
            object[] results = this.Invoke("UnpostedCautionMoneyReport", new object[] {
                        refundSlNo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UnpostedCautionMoneyReportAsync(string refundSlNo) {
            this.UnpostedCautionMoneyReportAsync(refundSlNo, null);
        }
        
        /// <remarks/>
        public void UnpostedCautionMoneyReportAsync(string refundSlNo, object userState) {
            if ((this.UnpostedCautionMoneyReportOperationCompleted == null)) {
                this.UnpostedCautionMoneyReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUnpostedCautionMoneyReportOperationCompleted);
            }
            this.InvokeAsync("UnpostedCautionMoneyReport", new object[] {
                        refundSlNo}, this.UnpostedCautionMoneyReportOperationCompleted, userState);
        }
        
        private void OnUnpostedCautionMoneyReportOperationCompleted(object arg) {
            if ((this.UnpostedCautionMoneyReportCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UnpostedCautionMoneyReportCompleted(this, new UnpostedCautionMoneyReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void DeleteCautionRefundLineCompletedEventHandler(object sender, DeleteCautionRefundLineCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteCautionRefundLineCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteCautionRefundLineCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetLinesCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void PostToJournalCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void PostedCautionMoneyReportCompletedEventHandler(object sender, PostedCautionMoneyReportCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PostedCautionMoneyReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PostedCautionMoneyReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void SubMitCautionMoneyCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void UnpostedCautionMoneyReportCompletedEventHandler(object sender, UnpostedCautionMoneyReportCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UnpostedCautionMoneyReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UnpostedCautionMoneyReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591