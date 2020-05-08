using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_Testing_InfoViewModel
    {
        public string analysisCode { get; set; }
        public Nullable<int> specID { get; set; }
        public string specification { get; set; }
        public string method { get; set; }
        public string unit { get; set; }
        public Nullable<float> turnAroundTime { get; set; }
        public Nullable<bool> reformTestResult { get; set; }
        public string note { get; set; }
    }
}
