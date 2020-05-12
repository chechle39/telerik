using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_Testing_DataViewModel
    {
        public Nullable<long> iD { get; set; }
        public Nullable<long> matrixID { get; set; }
        public Nullable<long> specID { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double precision { get; set; }
        public string LOD { get; set; }
    }
}
