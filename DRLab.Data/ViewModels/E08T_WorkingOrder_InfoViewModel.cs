using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_WorkingOrder_InfoCbbViewModel
    {
        public string WOID { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public string EmpID { get; set; }
        public string LabID { get; set; }
        public string Specification { get; set; }
        public string WOIDPlusDate { get; set; }
    }
}
