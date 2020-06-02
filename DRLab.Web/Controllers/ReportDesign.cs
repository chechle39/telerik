using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Compatibility.System.Web;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class ReportDesign : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}
