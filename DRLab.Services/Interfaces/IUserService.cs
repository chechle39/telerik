using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUserViewModel>> GetAllUser();
        Task<bool> AddAsync(ApplicationUserViewModel userVm);
        Task DeleteAsync(int[] rq);
        Task<ApplicationUserViewModel> GetById(int id);
        Task UpdateAsync(ApplicationUserViewModel userVm);
    }
}
