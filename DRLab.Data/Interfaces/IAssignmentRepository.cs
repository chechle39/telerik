using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<List<AssignmentViewModel>> Getdata();
        Task<bool> SaveAssignment(int F_id, string[] F_Ds);
        Task<List<AssignmentViewModelUserandSpec>> GetDataUserandSpec(int id);
    }
}
