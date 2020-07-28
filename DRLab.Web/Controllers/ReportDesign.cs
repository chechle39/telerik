using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Compatibility.System.Web;
using DevExpress.XtraReports.Web.ReportDesigner;
using DRLab.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class ReportDesign : Controller
    {
        public IActionResult Index(string requestNumber, string reportName)
        {
            var search = new SerchSampleManagementReport()
            {
                RequestNumber = requestNumber,
                ReportName = reportName
            };
            return View(search);
        }

    }
}
