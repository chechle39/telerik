using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Pdf.Native;
using DRLab.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Ajax.Utilities;

namespace DRLab.Web.Controllers
{

    public class AssignmentController : BaseController
    {
        private readonly IAsiignmentService _e00T_AssignmentService;

        public class UserandSpec
            {
            public int F_userid { get; set; }
            public string[] Ds_Spec { get; set; }
            }
        public AssignmentController(IAsiignmentService AssignmentService)
        {
            _e00T_AssignmentService = AssignmentService;

        }
        public async Task<IActionResult> Index()
        {
            var result = await _e00T_AssignmentService.Getdata();
            return View(result);
        }
        public async Task<IActionResult> Getdatauser()
        {
            var data = await _e00T_AssignmentService.Getdata();
            return Json(data[0].datauser);
        }
        public async Task<IActionResult> GetDataTesting_Info([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _e00T_AssignmentService.Getdata();
            return Json(data[0].data.ToDataSourceResult(request));
        }
        public async Task<IActionResult> InsertAssiment([FromQuery] UserandSpec F_data)
        {
           var data = await _e00T_AssignmentService.Create(F_data.F_userid, F_data.Ds_Spec);
           return Json(data);
        }
        public async Task<IActionResult> GetDataFormTestingInfo()
        {
            var data = await _e00T_AssignmentService.Getdata();
            return Json(data[0].data);
        }
        public async Task<IActionResult> GetUserAndSpec([FromQuery] UserandSpec F_data)
        {
            var data = await _e00T_AssignmentService.IGetDataUserandSpec(F_data.F_userid);
            return Json(data);
        }

    }
}