using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class SampleMatrixController : BaseController
    {
        private readonly IE00T_SampleMatrixService _e00T_SampleMatrixService;
        public SampleMatrixController(IE00T_SampleMatrixService e00T_SampleMatrixService)
        {
            _e00T_SampleMatrixService = e00T_SampleMatrixService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<List<E00T_SampleMatrixViewModel>> GetSampleMatrix(string text)
        {
            return await _e00T_SampleMatrixService.GetAllSampleMatrix(text);
        }
        public async Task<ActionResult> SampleMatrix_Create(E00T_SampleMatrixViewModel data_request)
        {

            if (data_request != null)
            {
                await _e00T_SampleMatrixService.Create(data_request);
            }
            return Ok();
        }
    }
}