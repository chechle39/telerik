using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E00T_Customer_ItemViewModel
    {
        public long contactID { get; set; }
        public string customerCode { get; set; }
        public string contactName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string note { get; set; }
    }
}
