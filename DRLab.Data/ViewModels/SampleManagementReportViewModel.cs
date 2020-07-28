using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class SampleManagementReportViewModel
    {
       
        public string requestNo { get; set; }    
        public Nullable<System.DateTime> receivceDate { get; set; }       
        public Nullable<System.DateTime> analysingDate { get; set; }
        public Nullable<System.DateTime> dateOfSendingResult { get; set; }
        public string sampleMatrix { get; set; }       
        public string sampleCode { get; set; }      
        public string companyName { get; set; }   
        public string sampleName { get; set; }     
        public string sampleDescription { get; set; }     
        public string nameofSample { get; set; }
        public string specification { get; set; }
        public string result { get; set; }
        public string Unit { get; set; }
        public string method { get; set; }
        public string companyAddress { get; set; }       

    }
    public class SampleManagementPrintGroupViewModel {
        public string Specification { get; set; }
        public List<SampleManagementPrintViewModel> ListData { get; set; }
    }
    public class SampleManagementPrintViewModel
    {
        public string requestNo { get; set; }
        public string sampleMatrix { get; set; }
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string companyName { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }    
        public string Specification { get; set; }      
        public string Unit { get; set; }
        public string Method { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public float precision { get; set; }
        public float Result { get; set; }
        public string contactName { get; set; }
        public DateTime dateOfSendingResult { get; set; }
    }
    public class SampleManagementDetailReportViewModel
    {
        public string Parameter { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string testMethod { get; set; }
        public string ResultText { get; set; }

    }
}
