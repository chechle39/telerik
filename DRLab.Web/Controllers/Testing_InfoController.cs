using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using DRLab.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DRLab.Web.Controllers
{
    public class Testing_InfoController : BaseController
    {
        private readonly ILogger<Testing_InfoController> _logger;
        private readonly ITesting_InfoService _testDataService;
        private readonly ISpecificationService _specificationDataService;
        private readonly IE00T_CustomerService _customerService;
        public Testing_InfoController(ILogger<Testing_InfoController> logger,ITesting_InfoService testDataService, ISpecificationService specificationDataService, IE00T_CustomerService customerService)
        { 
            _logger = logger;
            _testDataService = testDataService;
            _specificationDataService = specificationDataService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _specificationDataService.GetAll();
            ViewData["categories"] = result.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Read_Testing_Info([DataSourceRequest] DataSourceRequest request)
        {
            return Json((await _testDataService.GetAllTesting_Info()).ToDataSourceResult(request));
        }
        public async Task<ActionResult> TestingInfo_CreateAsync([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E08T_Testing_InfoViewModel> data_info)
        {
            var results = new List<E08T_Testing_InfoViewModel>();

            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    
                        await _testDataService.Create(data);
                        results.Add(data);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }
        public async Task<ActionResult> TestingInfo_UpdateAsync([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E08T_Testing_InfoViewModel> data_info)
        {
            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        await _testDataService.Update(data);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }
        public ActionResult TestingInfo_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E08T_Testing_InfoViewModel> data_info)
        {
            if (data_info.Any())
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {

                        _testDataService.Destroy(data.analysisCode);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }
        
        public async Task<List<E08T_Testing_InfoViewModel>> GetTestingInfoCombobox(string text)
        {
            return await _testDataService.GetE08TTestingInfoCombobox(text);
        }
        [HttpGet]
        public async Task<List<E00T_CustomerGridViewModel>> GetTestingInfoBySpecId(string id)
        {
            return await _testDataService.GetE08TTestingInfoBySpecId(id);
        }
        [HttpGet]
        public async Task<List<E08T_Testing_InfoViewModel>> GetTestingInfoComboboxByMatrix(long id)
        {
            return await _testDataService.GetE08TTestingInfoComboboxByMatrix(id);
        }
        [HttpGet]
        public async Task<ActionResult> GetTestingInfoByMatrix(long id)
        {
            return Ok(await _testDataService.GetE08TTestingInfoByMtID(id));
        }
        public async Task<List<E00T_SpecificationViewModel>> GetspecificationItem()
        {

            return await _specificationDataService.GetAll();
        }
        [HttpPost]
        public async Task<ActionResult> TestingInfo_CreatePopup([DataSourceRequest] DataSourceRequest request, E08T_Testing_PopupViewModel data_info)
        {

            if (data_info != null)
            {
                await _testDataService.CreatePopup(data_info);
            }
          
            return new OkObjectResult(data_info);
        }
    }
}