using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_TemplateMarkService : IE08T_TemplateMarkService
    {
        private readonly IUnitOfWork _uow;
        public readonly IE08T_TemplateMarkRepository _e08T_TemplateMarkRepository;
        public E08T_TemplateMarkService(IUnitOfWork uow, IE08T_TemplateMarkRepository e08T_TemplateMarkRepository)
        {
            _uow = uow;
            _e08T_TemplateMarkRepository = e08T_TemplateMarkRepository;
        }
        public async Task<bool> InsertEntity(List<E08T_TemplateMarkViewModel> request)
        {
            var save =  await _e08T_TemplateMarkRepository.InsertEntity(request);
            try
            {
                _uow.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(save);
        }

        public async Task<List<E00T_CustomerGridViewModel>> GetAllE08TTemplateMark(E08T_TemplateMarkSearch request)
        {
            return await _e08T_TemplateMarkRepository.GetAllE08TTemplateMark(request);
        }
    }
}
