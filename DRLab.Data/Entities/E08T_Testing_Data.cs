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

    public partial class E08T_Testing_Data
    {
        public E08T_Testing_Data() { 

        }

        public E08T_Testing_Data(int? iD, string lOD, long? matrixID, float? max, float? min, float? precision, int? specID)
        {
            this.iD = iD;
            LOD = lOD;
            this.matrixID = matrixID;
            this.max = max;
            this.min = min;
            this.precision = precision;
            this.specID = specID;
        }
        [Key]
        public Nullable<int> iD { get; set; }
        public Nullable<long> matrixID { get; set; }
        public Nullable<int> specID { get; set; }
        public Nullable<float> min { get; set; }
        public Nullable<float> max { get; set; }
        public Nullable<float> precision { get; set; }
        public string LOD { get; set; }
    
        public virtual E00T_SampleMatrix E00T_SampleMatrix { get; set; }
        public virtual E00T_Specification E00T_Specification { get; set; }
    }
}