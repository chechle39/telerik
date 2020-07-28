using AutoMapper;
using AutoMapper.QueryableExtensions;
using DRLab.Data.Identity;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddAsync(ApplicationUserViewModel userVm)
        {
            var user = new AppUser()
            {
                UserName = userVm.Email,
                Avatar = userVm.Avatar,
                Email = userVm.Email,
                FullName = userVm.FullName,
                DateCreated = DateTime.Now,
                PhoneNumber = userVm.PhoneNumber,
                BirthDay = userVm.BirthDay,
                Gender = userVm.Gender,
                Status = userVm.Status,
                Address = userVm.Address
            };

            var result = await _userManager.CreateAsync(user, userVm.Password);
            if (result.Succeeded && userVm.Roles.Count > 0)
            {
                List<string> role = new List<string>();
                var x = await _roleManager.FindByIdAsync(userVm.Roles[0]);
                var nameRole = x.Name;
                role.Add(nameRole);
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                if (appUser != null)
                {
                    await _userManager.AddToRolesAsync(appUser, role);
                }
                    
            }


            return await Task.FromResult(result.Succeeded);
        }

        public async Task DeleteAsync(int[] rq)
        {
            foreach (var item in rq)
            {
                var user = await _userManager.FindByIdAsync(item.ToString());
                await _userManager.DeleteAsync(user);
            }
        }

        public async Task<List<ApplicationUserViewModel>> GetAllUser()
        {
            var data = await _userManager.Users.ProjectTo<ApplicationUserViewModel>().ToListAsync();
            return data;
        }

        public async Task<ApplicationUserViewModel> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = Mapper.Map<AppUser, ApplicationUserViewModel>(user);
            userVm.Roles = roles.ToList();
            return userVm;
        }

        public async Task UpdateAsync(ApplicationUserViewModel userVm)
        {
            var user = await _userManager.FindByIdAsync(userVm.Id.ToString());
            //Remove current roles in db
            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user,
            userVm.Roles.Except(currentRoles).ToArray());

            if (result.Succeeded)
            {
                string[] needRemoveRoles = currentRoles.Except(userVm.Roles).ToArray();
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);


                //Update user detail
                user.FullName = userVm.FullName;
                user.Status = userVm.Status;
                user.Email = userVm.Email;
                user.UserName = userVm.Email;
                user.PhoneNumber = userVm.PhoneNumber;
                user.Gender = userVm.Gender;
                user.BirthDay = userVm.BirthDay;
                user.Address = userVm.Address;
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
