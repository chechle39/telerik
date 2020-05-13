using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DRLab.Web.Controllers
{
    public class AnalysisRequestDataController : Controller
    {
        //private readonly IE08T_AnalysisRequest_DataService _e08T_AnalysisRequest_DataService;
        //public AnalysisRequestDataController(IE08T_AnalysisRequest_DataService e08T_AnalysisRequest_DataService)
        //{
        //    _e08T_AnalysisRequest_DataService = e08T_AnalysisRequest_DataService;
        //}
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveEntity(List<CreateCustomeRequest> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(allErrors);
        //    }
        //    await _e08T_AnalysisRequest_DataService.CreateAnalysisRequestData(request);
        //    return new OkObjectResult(request);
        //}
    }
}