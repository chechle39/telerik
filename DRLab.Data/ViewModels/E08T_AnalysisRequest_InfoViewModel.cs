using System;

namespace DRLab.Data.ViewModels
{
    public class E08T_AnalysisRequest_InfoViewModel
    {
        public string requestNo { get; set; }
        public string customerID { get; set; }
        public Nullable<System.DateTime> receivceDate { get; set; }
        public Nullable<System.DateTime> dateOfSendingResult { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<bool> orderConfim { get; set; }
        public Nullable<long> contactID { get; set; }
        public string testReportContactID { get; set; }
        public Nullable<int> numberSample { get; set; }
        public Nullable<int> printVAT { get; set; }
        public string priceID { get; set; }
        public string note { get; set; }

    }
    public class E08T_AnalysisRequest_InfoViewModelStringDate
    {
        public string requestNo { get; set; }
        public string customerID { get; set; }
        public string receivceDate { get; set; }
        public string dateOfSendingResult { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<bool> orderConfim { get; set; }
        public Nullable<long> contactID { get; set; }
        public string testReportContactID { get; set; }
        public Nullable<int> numberSample { get; set; }
        public Nullable<int> printVAT { get; set; }
        public string priceID { get; set; }
        public string note { get; set; }

    }
    public class Couter
    {
        public string requestNo { get; set; }
        public string sampleCode { get; set; }
        public string inLabCode { get; set; }
        public string analysisCode { get; set; }
    }

    public class AnalysisRequest_Info
    {
        public Nullable<int> numberSample { get; set; }
        public string requestNo { get; set; }
        public string customerID { get; set; }
        public Nullable<System.DateTime> receivceDate { get; set; }
        public Nullable<System.DateTime> dateOfSendingResult { get; set; }
        public long contactID { get; set; }
        public string customerCode { get; set; }
        public string contactName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string note { get; set; }
    }

    public class AnalysisRequest_InfoStringDate
    {
        public Nullable<int> numberSample { get; set; }
        public string requestNo { get; set; }
        public string customerID { get; set; }
        public string receivceDate { get; set; }
        public string dateOfSendingResult { get; set; }
        public long contactID { get; set; }
        public string customerCode { get; set; }
        public string contactName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string note { get; set; }
    }
}
