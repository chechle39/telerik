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

    public partial class E08T_AnalysisRequest_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public E08T_AnalysisRequest_Item()
        {
            this.E08T_AnalysisRequest_Data = new HashSet<E08T_AnalysisRequest_Data>();
        }
    
        [Key]
        public string requestNo { get; set; }
        [Key]
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }
        public string weight { get; set; }
        public string remarkToLab { get; set; }
        public Nullable<bool> detected { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<E08T_AnalysisRequest_Data> E08T_AnalysisRequest_Data { get; set; }
        public virtual E08T_AnalysisRequest_Info E08T_AnalysisRequest_Info { get; set; }
    }
}
