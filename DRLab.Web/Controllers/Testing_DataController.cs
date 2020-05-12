using DRLab.Services.Interfaces;
using DRLab.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class Testing_DataController : Controller
    {
        private readonly ILogger<Testing_DataController> _logger;
        private readonly ITesting_DataService _testDataService;

        public Testing_DataController(ILogger<Testing_DataController> logger, ITesting_DataService testDataService)
        {
            _logger = logger;
            _testDataService = testDataService;
        }
   
        public async Task<IActionResult> Index()
        {
         
            return View();
        }
      
        public async Task<IActionResult> Products_Create()
        {
            return View();
        }
        public async Task<IActionResult> Read_Testing_Data([DataSourceRequest] DataSourceRequest request)
        {
           
            return Json((await _testDataService.GetAllTesting_Data()).ToDataSourceResult(request));
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
    }
}