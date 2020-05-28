using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.Entities
{
    public partial class E08T_WorkingOrder_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public E08T_WorkingOrder_Info()
        {
            this.E08T_WorkingOrder_Item = new HashSet<E08T_WorkingOrder_Item>();
        }
        [Key]
        public string WOID { get; set; }
        public DateTime DateCreate { get; set; }
        public string EmpID { get; set; }
        public string LabID { get; set; }
        public string Specification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<E08T_WorkingOrder_Item> E08T_WorkingOrder_Item { get; set; }
    }
}
