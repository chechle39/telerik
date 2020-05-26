using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class CustomerListController : BaseController
    {
        private readonly ILogger<CustomerListController> _logger;
        private readonly IE00T_CustomerService _customerService;
        public CustomerListController(ILogger<CustomerListController> logger, IE00T_CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;

        }

        public async Task<IActionResult> Index()
        {
            var result = await _customerService.GetAll();
            ViewData["categories"] = result.ToList();
            return View();
           
        }

        public async Task<IActionResult> Read_Customer([DataSourceRequest] DataSourceRequest request)
        {
           
            return Json((await _customerService.GetListCustomer()).ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create_Customer([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<E00T_CustomerViewModel> data_info)
        {
            var result = new List<E00T_CustomerViewModel>();

          
                foreach (var data in data_info)
                {
                    if (data !=null) {
                        await _customerService.Create(data);
                        result.Add(data);
                    }

                }
           
            return Json(result.ToDataSourceResult(request, ModelState));
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
        [HttpPost]
        public async Task<ActionResult> Create_CustomerRequest([DataSourceRequest] DataSourceRequest request, E00T_CustomerViewModel customer_request)
        {
            await _customerService.Create(customer_request);                                      
            return Json((await _customerService.GetListCustomer()).ToDataSourceResult(request, ModelState));
        }

    }
}