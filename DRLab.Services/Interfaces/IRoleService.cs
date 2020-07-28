using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<ApplicationRoleViewModel>> GetAllAsync(string text);
        Task<bool> AddAsync(ApplicationRoleViewModel roleVm);
    }
}
