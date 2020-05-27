using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using DRLab.Web.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace DRLab.Web.Areas.API.Controllers
{
   

    public class CustomerItemController : BaseController
    {
        private readonly ILogger<CustomerListController> _logger;
        private readonly IE00T_Customer_ItemService _customer_ItemService;
        private readonly ISpecificationService _specificationDataService;
        public CustomerItemController(ILogger<CustomerListController> logger, IE00T_Customer_ItemService customer_ItemService, ISpecificationService specificationDataService)
        {
            _logger = logger;
            _customer_ItemService = customer_ItemService;
            _specificationDataService = specificationDataService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
      
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Read_Customer([DataSourceRequest] DataSourceRequest request)
        {
           
            return Json((await _customer_ItemService.GetListCustomerItem()).ToDataSourceResult(request));
        }
        [HttpPost]
        public async Task<ActionResult> Create_Customer([FromBody]E00T_Customer_ItemViewModel req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            try {
                await _customer_ItemService.Create(req);
            } catch (Exception ex) { 
            }
            return new OkObjectResult(req);
        }
        [HttpPost]
        public async Task<ActionResult> Update_Customer([DataSourceRequest] DataSourceRequest request, E00T_Customer_ItemViewModel data_info)
        {
            if (data_info != null && ModelState.IsValid)
            {                  
                     await   _customer_ItemService.Update(data_info);                   
            }

            return Json((await _customer_ItemService.GetListCustomerItem()).ToDataSourceResult(request, ModelState));
        }
       
        public async Task<ActionResult> Destroy_Customer([DataSourceRequest] DataSourceRequest request, long Id)
        {
           
                    if (Id != null)
                    {
                        _customer_ItemService.Destroy(Id);
                    }


            return Json((await _customer_ItemService.GetListCustomerItem()).ToDataSourceResult(request, ModelState));
        }

       
      
    }
}