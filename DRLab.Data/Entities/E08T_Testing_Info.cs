//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DRLab.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class E08T_Testing_Info
    {
        public E08T_Testing_Info() { 

        }

        public E08T_Testing_Info(string analysisCode, int? specID1, string specification, string method, string unit, float? turnAroundTime, bool? reformTestResult)
        {
            this.analysisCode = analysisCode;
            this.specID = specID;
            this.specification = specification;
            this.method = method;
            this.unit = unit;
            this.turnAroundTime = turnAroundTime;
            this.reformTestResult = reformTestResult;
        }

        public string analysisCode { get; set; }
        public Nullable<int> specID { get; set; }
        public string specification { get; set; }
        public string method { get; set; }
        public string unit { get; set; }
        public Nullable<double> turnAroundTime { get; set; }
        public Nullable<bool> reformTestResult { get; set; }
        public string note { get; set; }
    
        public virtual E00T_Specification E00T_Specification { get; set; }
    }
}
