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
    public class Testing_InfoController : Controller
    {
        private readonly ILogger<Testing_InfoController> _logger;
        private readonly ITesting_InfoService _testDataService;
        private readonly ISpecificationService _specificationDataService;
        public Testing_InfoController(ILogger<Testing_InfoController> logger, ITesting_InfoService testDataService, ISpecificationService specificationDataService)
        {
            _logger = logger;
            _testDataService = testDataService;
            _specificationDataService = specificationDataService;
        }

        public async Task<IActionResult> Index()
        {
           await PopulateCategories();
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
                    if (data != null) {
                        await _testDataService.Create(data);
                       
                    }               
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }
        public ActionResult TestingInfo_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E08T_Testing_InfoViewModel> data_info)
        {
            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        _testDataService.Update(data);
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
        public async Task<List<E00T_SpecificationViewModel>> PopulateCategories()
        {
            
            
            var result = await _specificationDataService.GetAll();
            ViewData["categories"] = result.ToList();
            return result;
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
    }
}