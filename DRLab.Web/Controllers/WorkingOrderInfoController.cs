using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class WorkingOrderInfoController : Controller
    {
        private readonly IE08T_WorkingOrder_InfoService _e08T_WorkingOrder_InfoService;
        public WorkingOrderInfoController(IE08T_WorkingOrder_InfoService e08T_WorkingOrder_InfoService)
        {
            _e08T_WorkingOrder_InfoService = e08T_WorkingOrder_InfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkingOrderInfoCbb(string start, string end)
        {
            var data = await _e08T_WorkingOrder_InfoService.E08T_WorkingOrder_InfoCbb(start, end);
            return Ok(data);
        }

    }
}