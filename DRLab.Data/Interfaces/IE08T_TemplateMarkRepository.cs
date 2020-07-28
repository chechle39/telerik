using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_TemplateMarkRepository
    {
        public Task<bool> InsertEntity(List<E08T_TemplateMarkViewModel> request);
        public Task<List<E00T_CustomerGridViewModel>> GetAllE08TTemplateMark(E08T_TemplateMarkSearch request);
    }
}
