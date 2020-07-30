using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class LabManagmentController : Controller
    {
        private readonly ILabManagmentDapperService _labManagmentDapperService;
        public LabManagmentController(ILabManagmentDapperService labManagmentDapperService)
        {
            _labManagmentDapperService = labManagmentDapperService;
        }
        public IActionResult Index(string start, string end)
        {
            var search = new SerchGridManagement()
            {
                StartDate = start,
                EndDate = end,
            };
            return View(search);
        }
        [HttpGet]
        public async Task<IActionResult> GetLabManagmentList(SerchGridManagement rq)
        {
            return Ok(await _labManagmentDapperService.GetLabManagment(rq));
        }

    }
}