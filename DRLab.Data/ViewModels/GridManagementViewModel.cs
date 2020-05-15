using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class GridManagementViewModel
    {
        [Display(Name = "Request No#")]
        public string requestNo { get; set; }
        [Display(Name = "Receive Date")]
        public Nullable<System.DateTime> receivceDate { get; set; }
        [Display(Name = "Customer Name")]
        public string companyName { get; set; }
        [Display(Name = "Contact Name")]
        public string contactName { get; set; }
        [Display(Name = "Expected Date")]
        public Nullable<System.DateTime> dateOfSendingResult { get; set; }
        [Display(Name = "Request Status")]
        public Nullable<int> status { get; set; }
    }

    public class SerchGridManagement
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Customer { get; set; }
    }
}
