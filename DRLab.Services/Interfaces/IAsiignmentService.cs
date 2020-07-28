using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
  public interface IAsiignmentService
    {
        Task<List<AssignmentViewModel>> Getdata();
        Task<bool> Create(int F_id,string[] F_Ds);
        Task<List<AssignmentViewModelUserandSpec>> IGetDataUserandSpec(int id);

    }
}
