using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E08T_Testing_DataViewModel
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> matrixID { get; set; }
        public Nullable<int> specID { get; set; }
        public Nullable<float> min { get; set; }
        public Nullable<float> max { get; set; }
        public Nullable<float> precision { get; set; }
        public string LOD { get; set; }
    }
}
