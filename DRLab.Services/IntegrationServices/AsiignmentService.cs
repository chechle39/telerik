using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
   public class AsiignmentService : IAsiignmentService
    {
        private readonly IAssignmentRepository _AssignmentRepository;
        private readonly IRepository<Assignment> _test;
        private readonly IUnitOfWork _uow;
        public AsiignmentService(IUnitOfWork uow, IAssignmentRepository AssignmentRepository)
        {
            _AssignmentRepository = AssignmentRepository;
            _uow = uow;
            _test = _uow.GetRepository<IRepository<Assignment>>();
        }

        public async Task<bool> Create(int F_id,string[] F_Ds)
        {
            await _AssignmentRepository.SaveAssignment(F_id,F_Ds);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
        public async Task<List<AssignmentViewModel>> Getdata()
        {
            return await _AssignmentRepository.Getdata();
        }

        public async Task<List<AssignmentViewModelUserandSpec>> IGetDataUserandSpec(int id)
        {
            return await _AssignmentRepository.GetDataUserandSpec(id);
        }
    }
}
