using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class Testing_InfoService : ITesting_InfoService
    {
        private static bool UpdateDatabase = false;
        private readonly IRepository<E08T_Testing_Info> _test;
        private readonly ISpecificationService _Specifi;
        private readonly IUnitOfWork _uow;
        private readonly IE08T_Testing_InfoRepository _e08T_Testing_InfoRepository;
        public Testing_InfoService(IUnitOfWork uow, ISpecificationService Specifi, IE08T_Testing_InfoRepository e08T_Testing_InfoRepository)
        {
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E08T_Testing_Info>>();
            _Specifi = Specifi;
            _e08T_Testing_InfoRepository = e08T_Testing_InfoRepository;
        }
       
        public async Task<IEnumerable<E08T_Testing_InfoViewModel>> GetAllTesting_Info()
        {

            var resultsList = new List<E08T_Testing_InfoViewModel>();
            var test = _test.GetAll().ProjectTo<E08T_Testing_InfoViewModel>().AsEnumerable();
            foreach (var data in test)
            {
                var result = new E08T_Testing_InfoViewModel();
              
                {
                    result.analysisCode = data.analysisCode;
                    result.specID = data.specID;
                    result.specification = data.specification;
                    result.method = data.method;
                    result.unit = data.unit;
                    result.turnAroundTime = data.turnAroundTime;
                    result.reformTestResult = data.reformTestResult;
                    result.note = data.note;                

                }

                resultsList.Add(result);


                
            }

            return resultsList.AsEnumerable();
        }
       
        public async Task<E08T_Testing_InfoViewModel> Create(E08T_Testing_InfoViewModel Data)
        {
            if (Data.specID != null)
            {
                var client = new E08T_Testing_Info()
                {

                    analysisCode = Data.analysisCode,
                    specID = Data.specID,
                    specification = Data.specification,
                    method = Data.method,
                    unit = Data.unit,
                    turnAroundTime = Data.turnAroundTime,
                    reformTestResult = Data.reformTestResult,
                    note = Data.note,
                };
                _test.Add(client);
                _uow.SaveChanges();
            }
            else {
                var request = new E00T_SpecificationViewModel();
                {
                    request.specID = null;
                    request.specification = Data.specification;
                }
                await _Specifi.Create(request);
                var resultId = new List<E00T_SpecificationViewModel>();
                resultId = await _Specifi.GetbyName(Data.specification);
                var client = new E08T_Testing_Info()
                {
                    analysisCode = Data.analysisCode,
                    specID = resultId[0].specID,
                    specification = Data.specification,
                    method = Data.method,
                    unit = Data.unit,
                    turnAroundTime = Data.turnAroundTime,
                    reformTestResult = Data.reformTestResult,
                    note = Data.note,
                };
                _test.Add(client);
                _uow.SaveChanges();
            }      
            return null;
        }

        public async Task<E08T_Testing_InfoViewModel> Update(E08T_Testing_InfoViewModel Data)
        {
            var specifi = new List<E00T_SpecificationViewModel>();
            specifi = await _Specifi.GetbyId(Data.specID);
            var client = new E08T_Testing_Info()
            {

                analysisCode = Data.analysisCode,
                specID = Data.specID,
                specification = specifi[0].specification,
                method = Data.method,
                unit = Data.unit,
                turnAroundTime = Data.turnAroundTime,
                reformTestResult = Data.reformTestResult,
                note = Data.note,
            };
            _test.Update(client);
            _uow.SaveChanges();
            return null;
        }

        public void Destroy(string id)
        {
            if (id != null) {
                _test.RemoveStringID(id);
                _uow.SaveChanges();
            }      
        }

        public async Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoCombobox(string text)
        {
            return await _e08T_Testing_InfoRepository.GetE08TTestingInfoCombobox(text);
        }

        public async Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoBySpecId(string analysisCode)
        {
            return await _e08T_Testing_InfoRepository.GetE08TTestingInfoBySpecId(analysisCode);
        }

        public async Task<E08T_Testing_InfoViewModel1> CreateWithCombobox(E08T_Testing_InfoViewModel1 Data)
        {
            if (Data.newspecification != null)
            {
                var request = new E00T_SpecificationViewModel();
                {
                    request.specID = null;
                    request.specification = Data.newspecification;
                }
                await _Specifi.Create(request);
                var resultId = new List<E00T_SpecificationViewModel>();
                resultId = await _Specifi.GetbyName(Data.newspecification);
                var client = new E08T_Testing_Info()
                {
                    analysisCode = Data.analysisCode,
                    specID = resultId[0].specID,
                    specification = Data.newspecification,
                    method = Data.method,
                    unit = Data.unit,
                    turnAroundTime = Data.turnAroundTime,
                    reformTestResult = Data.reformTestResult,
                    note = Data.note,
                };
                _test.Add(client);
                _uow.SaveChanges();
            }
            else {
                if (Data.specification != null)
                {
                    var specifi = await _Specifi.GetbyName(Data.specification);
                    var client = new E08T_Testing_Info()
                    {

                        analysisCode = Data.analysisCode,
                        specID = specifi[0].specID,
                        specification = Data.specification,
                        method = Data.method,
                        unit = Data.unit,
                        turnAroundTime = Data.turnAroundTime,
                        reformTestResult = Data.reformTestResult,
                        note = Data.note,
                    };
                    _test.Add(client);
                    _uow.SaveChanges();
                }
            }


            
            return null;
        }
    }
    
}
