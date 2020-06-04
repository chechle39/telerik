using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class SampleManagementViewModel
    {
        [Display(Name = "Request No#")]
        public string requestNo { get; set; }
        [Display(Name = "Receive Date")]
        public Nullable<System.DateTime> receivceDate { get; set; }
        [Display(Name = "Completed On")]
        public Nullable<System.DateTime> completedOn { get; set; }
        [Display(Name = "Lab Code")]
        public string labCode { get; set; }
        [Display(Name = "Sample Code")]
        public string sampleCode { get; set; }
        [Display(Name = "Sample Name")]
        public string sampleName { get; set; }
        [Display(Name = "Contact Name")]
        public string contactName { get; set; }
        [Display(Name = "Company Name")]
        public string companyName { get; set; }
        [Display(Name = "Expected Date")]
        public Nullable<System.DateTime> expectedDate { get; set; }
        [Display(Name = "Request Status")]
        public Nullable<int> Status { get; set; }
        [Display(Name = "Customer Code")]
        public string customerCode { get; set; }
        [Display(Name = "Total")]
        public int Total { get; set; }
        [Display(Name = "Accept")]
        public int Accept { get; set; }
        [Display(Name = "Reject")]
        public int Reject { get; set; }
        [Display(Name = "Approve")]
        public int Approve { get; set; }

    }

    public class SerchSampleManagement
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string[] Customer { get; set; }
    }
}
