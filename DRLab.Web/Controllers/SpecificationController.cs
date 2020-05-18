using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class SpecificationController : Controller
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
    }
}