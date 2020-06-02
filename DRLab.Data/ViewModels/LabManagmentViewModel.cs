using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class LabManagmentViewModel
    {
        public string requestNo { get; set; }
        public DateTime? ExpectationDate { get; set; }
        public DateTime? receivceDate { get; set; }
        public float TotalSample { get; set; }
        public float TotalSpec { get; set; }
        public int Recorded { get; set; }
        public int Accepted { get; set; }
        public int RequestStatus { get; set; }
    }
}
