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
using Microsoft.Extensions.Logging;

namespace DRLab.Web.Areas.API.Controllers
{
   

    public class CustomerItemController : BaseController
    {
        private readonly ILogger<CustomerListController> _logger;
        private readonly IE00T_Customer_ItemService _customer_ItemService;
        private readonly IE00T_CustomerService _e00T_CustomerService;
        public CustomerItemController(ILogger<CustomerListController> logger, IE00T_Customer_ItemService customer_ItemService, IE00T_CustomerService e00T_CustomerService)
        {
            _logger = logger;
            _customer_ItemService = customer_ItemService;
            _e00T_CustomerService = e00T_CustomerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _e00T_CustomerService.GetAll();
            ViewData["categories"] = result.ToList();
            ViewData["defaultvalue"] = result.First();
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
        public async Task<ActionResult> Create_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_Customer_ItemViewModel> data_info)
        {
            var results = new List<E00T_Customer_ItemViewModel>();

            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        await _customer_ItemService.Create(data);
                        results.Add(data);
                    }

                }
            }
            return Json((await _customer_ItemService.GetListCustomerItem()).ToDataSourceResult(request, ModelState));
        }
        public ActionResult Update_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_Customer_ItemViewModel> data_info)
        {
            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        _customer_ItemService.Update(data);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Destroy_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_Customer_ItemViewModel> data_info)
        {
            if (data_info.Any())
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        _customer_ItemService.Destroy(data.contactID);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }

       
      
    }
}