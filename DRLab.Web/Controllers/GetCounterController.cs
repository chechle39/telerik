using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class GetCounterController : Controller
    {
        private readonly IGetRequestNoDapperService _getRequestNoDapperService;
        public GetCounterController(IGetRequestNoDapperService getRequestNoDapperService)
        {
            _getRequestNoDapperService = getRequestNoDapperService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCounterString([FromBody]string[] request)
        {
            var data = await _getRequestNoDapperService.GetRequestNo(request);
            return Ok(data);
        }
    }
}