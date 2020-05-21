using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class CustomerRequestController : BaseController
    {
        private readonly IE00T_CustomerService _e00T_CustomerService;
        private readonly IE00T_Customer_ItemService _e00T_Customer_ItemService;
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        private readonly ISpecificationService _specificationDataService;
        public CustomerRequestController(IE00T_CustomerService e00T_CustomerService, 
            IE00T_Customer_ItemService e00T_Customer_ItemService, 
            IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, ISpecificationService specificationDataService)
        {
            _e00T_CustomerService = e00T_CustomerService;
            _e00T_Customer_ItemService = e00T_Customer_ItemService;
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
            _specificationDataService = specificationDataService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _specificationDataService.GetAll();
            ViewData["categories"] = result.ToList();
            return View();
        }
        public async Task<IActionResult> DetailCustomer(string requestNo)
        {
            var result = await _specificationDataService.GetAll();
            ViewData["categories"] = result.ToList();
            ViewData["Analysis"] = await _e00T_CustomerService.GetAnalysisByRequestNo(requestNo);
            return View(await _e08T_AnalysisRequest_InfoService.GetRequestInfoByRequestNo(requestNo));
        }
        [HttpPost]
        public async Task<IActionResult> SaveEntityAnalysisRequestData([FromBody] List<CreateCustomeRequest> request)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e00T_CustomerService.CreateAnalysisRequestData(request);
            return new OkObjectResult(request);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEntity([FromBody]E08T_AnalysisRequest_InfoViewModel req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_AnalysisRequest_InfoService.SaveAnalysisRequestInfo(req);
            return new OkObjectResult(req);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEntity(E08T_AnalysisRequest_InfoViewModel req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_AnalysisRequest_InfoService.UpdateAnalysisRequestInfo(req);
            return new OkObjectResult(req);
        }
        public async Task<List<E00T_CustomerViewModel>> GetCustomers(string text)
        {
            return await _e00T_CustomerService.GetCustomer(text);
        }
        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomersItem(string text)
        {
            return await _e00T_Customer_ItemService.GetCustomerItem(text);
        }
        [HttpGet]
        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomersItemByCode(string id)
        {
            return await _e00T_Customer_ItemService.GetE00T_Customer_ItemByCode(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalysisByRequestNo(string requestNo)
        {
            return Ok(await _e00T_CustomerService.GetAnalysisByRequestNo(requestNo));
        }
    }
}