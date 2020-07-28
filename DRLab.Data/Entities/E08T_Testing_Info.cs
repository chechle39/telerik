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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class E08T_Testing_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public E08T_Testing_Info() {
          
        }
       
        public E08T_Testing_Info(string analysisCode, long? specID, string specification, string specCode,string method, string unit, double turnAroundTime, bool reformTestResult, string note)
        {
            this.analysisCode = analysisCode;
            this.specID = specID;
            this.specification = specification;
            this.specCode = specCode;
            this.method = method;
            this.unit = unit;
            this.turnAroundTime = turnAroundTime;
            this.reformTestResult = reformTestResult;
            this.note = note;
        }
        [Key]
        public string analysisCode { get; set; }
        public Nullable<long> specID { get; set; }
        public string specification { get; set; }
        public string specCode { get; set; }
        public string method { get; set; }
        public string unit { get; set; }
        public double turnAroundTime { get; set; }
        public bool reformTestResult { get; set; }
        public string note { get; set; }
        [ForeignKey("specID")]
        public virtual E00T_Specification Specif { get; set; }

    }
}
