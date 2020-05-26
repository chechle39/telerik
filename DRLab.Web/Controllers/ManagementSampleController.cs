using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class ManagementSampleController : Controller
    {
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        public ManagementSampleController(IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService)
        {
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetManagementSampleList(SerchSampleManagement rq)
        {
            return Ok(await _e08T_AnalysisRequest_InfoService.GetRequestInfoSample(rq));
        }

        [HttpPost]
        public async Task<IActionResult> DeletedAnalysisRequestInfo([FromBody]string[] request)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_AnalysisRequest_InfoService.DeleteAnalysisRequestInfo(request);
            return new OkObjectResult(request);
        }
    }
}