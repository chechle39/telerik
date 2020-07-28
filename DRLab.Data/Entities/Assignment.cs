using DRLab.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DRLab.Data.Entities
{
    public class Assignment
    {
        public Assignment(int id, long? specID, int? userId)
        {
            Id = id;
            this.specID = specID;
            UserId = userId;
        }
        public Assignment()
        {
        }
        public Assignment(int userid, long specID)
        {
            this.UserId = userid;
            this.specID = specID;
        }
        [Key]
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<long> specID { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("specID")]
        public virtual E00T_Specification E00T_Specification { get; set; }
    }
}