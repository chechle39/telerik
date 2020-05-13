using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_AnalysisRequest_ItemViewModel
    {
        public string requestNo { get; set; }
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }
        public string weight { get; set; }
        public string remarkToLab { get; set; }
        public Nullable<bool> detected { get; set; }
    }
}
