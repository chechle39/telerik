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

    public partial class E00T_SampleMatrix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public E00T_SampleMatrix()
        {
            this.E08T_Testing_Data = new HashSet<E08T_Testing_Data>();
        }
        public E00T_SampleMatrix(long? matrixID, string sampleMatrix)
        {
            this.matrixID = matrixID;
            this.sampleMatrix = sampleMatrix;
        }
        [Key]
        public Nullable<long> matrixID { get; set; }
        public string sampleMatrix { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<E08T_Testing_Data> E08T_Testing_Data { get; set; }
      
    
    }
}
