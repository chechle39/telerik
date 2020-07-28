using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Identity;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        private readonly IE08T_Testing_InfoRepository _e08T_Testing_InfoRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public AssignmentRepository(DbContext context, IE08T_Testing_InfoRepository Testing_InfoRepository, UserManager<AppUser> userManager, IUnitOfWork unitOfWork) : base(context)
        {
            _e08T_Testing_InfoRepository = Testing_InfoRepository;
            _userManager = userManager;
            _unitOfWork=unitOfWork;
        }

        public async Task<List<AssignmentViewModel>> Getdata()
        {
            var datauser = await _userManager.Users.ToListAsync();
            var datalist = new List<AssignmentViewModel>();
            var datatestinginfo = await _e08T_Testing_InfoRepository.Getdata();
            var dataAssignment = await Entities.ProjectTo<AssignmentViewModel>().ToListAsync();
            var Assign = new AssignmentViewModel()
            {
                data = datatestinginfo,
                datauser = datauser
            };
            datalist.Add(Assign);
            return datalist;
        }

        public async Task<List<AssignmentViewModelUserandSpec>> GetDataUserandSpec(int id)
        {
            var data = await Entities.ProjectTo<AssignmentViewModelUserandSpec>().Where(x => x.UserId == id).ToListAsync();
            return data;
        }

        public async Task<bool> SaveAssignment(int F_id,string[] F_Ds)
        {
            var deleteOldData = Entities.AsNoTracking().Where(x => x.UserId ==F_id).ToList();
            if (deleteOldData.Count() > 0)
            {
                Entities.RemoveRange(deleteOldData);
                _unitOfWork.SaveChanges();
            }

            var DS = JsonConvert.DeserializeObject<string[]>(F_Ds[0]);
            foreach (string Ds_Spec in DS)
            {
                long longValue = long.Parse(Ds_Spec);
                var Asign = new Assignment()
                { 
                    specID = longValue,
                    UserId = F_id                    
                };
                Entities.Add(Asign);
            }
            
            return await Task.FromResult(true);
        }
    }
}
