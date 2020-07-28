using AutoMapper.QueryableExtensions;
using DRLab.Data.Identity;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class RoleService : IRoleService
    {
        private RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> AddAsync(ApplicationRoleViewModel roleVm)
        {
            var role = new AppRole()
            {
                Name = roleVm.Name,
                Description = roleVm.Description,
            };
            var result = await _roleManager.CreateAsync(role);

            return result.Succeeded;
        }

        public async Task<List<ApplicationRoleViewModel>> GetAllAsync(string text)
        {
            var data = await _roleManager.Roles.ProjectTo<ApplicationRoleViewModel>().ToListAsync();
            if(!string.IsNullOrEmpty(text))
            {
                var lisrt = data.Where(x => x.Name.Contains(text));
                return lisrt.ToList(); ;
            }
            return data;
        }
    }
}
