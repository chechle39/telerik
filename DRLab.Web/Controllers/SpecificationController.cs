using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class SpecificationController : BaseController
    {
        private readonly ISpecificationService _specificationDataService;
        public SpecificationController(ISpecificationService specificationDataService)
        {
         
            _specificationDataService = specificationDataService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Specification_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json((await _specificationDataService.GetAll_IEnumerable()).ToDataSourceResult(request));
        }
        public async Task<ActionResult>Specification_Create([DataSourceRequest] DataSourceRequest request, E00T_SpecificationViewModel data_info)
        {
            
            if (data_info != null && ModelState.IsValid)
            {
                await _specificationDataService.Create(data_info);
            }
            return Json((await _specificationDataService.GetAll_IEnumerable()).ToDataSourceResult(request, ModelState));
        }
    }
}