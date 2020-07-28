using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DRLab.Web.Controllers
{
    public class TemplateMarkController : BaseController
    {
        private readonly IE08T_TemplateMarkService _e08T_TemplateMarkService;
        public TemplateMarkController(IE08T_TemplateMarkService e08T_TemplateMarkService) 
        {
            _e08T_TemplateMarkService = e08T_TemplateMarkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplateMarkList(E08T_TemplateMarkSearch rq)
        {
            return Ok(await _e08T_TemplateMarkService.GetAllE08TTemplateMark(rq));
        }
        [HttpPost]
        public async Task<IActionResult> SaveEntityTemplateMark([FromBody] List<E08T_TemplateMarkViewModel> request)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_TemplateMarkService.InsertEntity(request);
            return new OkObjectResult(request);
        }
    }
}
