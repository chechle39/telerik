using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_WorkingOrder_InfoService : IE08T_WorkingOrder_InfoService
    {
        private readonly IE08T_WorkingOrder_InfoRepository _e08T_WorkingOrder_InfoRepository;
        public E08T_WorkingOrder_InfoService(IE08T_WorkingOrder_InfoRepository e08T_WorkingOrder_InfoRepository)
        {
            _e08T_WorkingOrder_InfoRepository = e08T_WorkingOrder_InfoRepository;
        }

        public async Task<List<E08T_WorkingOrder_InfoCbbViewModel>> E08T_WorkingOrder_InfoCbb(string start, string end)
        {
            return await _e08T_WorkingOrder_InfoRepository.E08T_WorkingOrder_InfoCbb(start, end);
        }
    }
}
