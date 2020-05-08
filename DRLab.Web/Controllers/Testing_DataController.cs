using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Services.Interfaces;
using DRLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DRLab.Web.Controllers
{
    public class Testing_DataController : Controller
    {
        private readonly ILogger<Testing_DataController> _logger;
        //   private readonly ITesting_DataService _testDataService;

        public Testing_DataController(ILogger<Testing_DataController> logger)
        {
            _logger = logger;
            
        }

        //public async Task<IActionResult> Index()
        //{
        //    var x = await _testDataService.GetAllTesting_Data();
        //    return View();
        //}

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