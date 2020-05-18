using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class ManagementRequestController : Controller
    {
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        public ManagementRequestController(IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService)
        {
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetManagementRequestList(SerchGridManagement rq)
        {
            return Ok(await _e08T_AnalysisRequest_InfoService.GetRequestInfoGrid(rq));
        }
    }
}