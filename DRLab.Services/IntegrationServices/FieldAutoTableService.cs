using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class FieldAutoTableService : IFieldAutoTableService
    {
        public readonly IFieldAutoTableRepository _fieldAutoTableRepository;
        private readonly IUnitOfWork _uow;
        public FieldAutoTableService(IFieldAutoTableRepository fieldAutoTableRepository, IUnitOfWork uow)
        {
            _fieldAutoTableRepository = fieldAutoTableRepository;
            _uow = uow;
        }

        public async Task<bool> CreateTable(List<FieldAutoTableViewModel> request)
        {
            var save = await _fieldAutoTableRepository.CreateTable(request);
            _uow.SaveChanges();
            return save;
        }

        public async Task<List<RubberClassification>> GetFieldTableByCode(string code)
        {
            return await _fieldAutoTableRepository.GetFieldTableByCode(code);
        }
    }
}
