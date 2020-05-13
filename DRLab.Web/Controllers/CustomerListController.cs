﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DRLab.Web.Controllers
{
    public class CustomerListController : Controller
    {
        private readonly ILogger<CustomerListController> _logger;
        private readonly IE00T_CustomerService _customerService;
        public CustomerListController(ILogger<CustomerListController> logger, IE00T_CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Read_Customer([DataSourceRequest] DataSourceRequest request)
        {

            return Json((await _customerService.GetListCustomer()).ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_CustomerViewModel> data_info)
        {
            var results = new List<E00T_CustomerViewModel>();

            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data !=null) {
                        await _customerService.Create(data);
                        results.Add(data);
                    }

                }
            }
            return Json(results.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Update_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_CustomerViewModel> data_info)
        {
            if (data_info != null && ModelState.IsValid)
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        _customerService.Update(data);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Destroy_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_CustomerViewModel> data_info)
        {
            if (data_info.Any())
            {
                foreach (var data in data_info)
                {
                    if (data != null)
                    {
                        _customerService.Destroy(data.customerCode);
                    }
                }
            }

            return Json(data_info.ToDataSourceResult(request, ModelState));
        }
    }
}