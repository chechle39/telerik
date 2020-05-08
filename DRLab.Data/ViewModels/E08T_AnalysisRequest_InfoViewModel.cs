using System;
using System.Collections.Generic;
using System.Text;

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
}
