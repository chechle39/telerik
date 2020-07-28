using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_TemplateMarkViewModel
    {
        public string TenanId { get; set; }
        public string TemLateName { get; set; }
        public List<E08T_TemplateMarkGrid> Data { get; set; }
    }

    public class E08T_TemplateMarkGrid
    {
        public string AnalysisCode { get; set; }
        public string Specification { get; set; }
        public string Method { get; set; }
        public string Mark { get; set; }
        public string LOD { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public int Urgent { get; set; }
        public Nullable<double> turnAroundDay { get; set; }
    }
    public class E08T_TemplateMarkSearch
    {
        public string TenanId { get; set; }
        public string TemLateName { get; set; }
    }
}
