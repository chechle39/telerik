using DRLab.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long specID { get; set; }
        public List<E08T_Testing_InfoViewModel> data { get; set; }

        public List<AppUser> datauser { get; set; }
    }
    public class AssignmentViewModelUserandSpec
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long specID { get; set; }
    }
}
