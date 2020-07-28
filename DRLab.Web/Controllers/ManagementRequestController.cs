using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;
using Grpc.Core;

namespace DRLab.Web.Controllers
{
    public class ManagementRequestController : Controller
    {
        private readonly ISampleManagementReportDapper _iSampleManagementReportDapper;
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ManagementRequestController(ISampleManagementReportDapper iSampleManagementReportDapper,IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, IHostingEnvironment hostingEnvironment)
        {
            _iSampleManagementReportDapper = iSampleManagementReportDapper;
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> GetManagementRequestList(SerchGridManagement rq)
        {
            return Ok(await _e08T_AnalysisRequest_InfoService.GetRequestInfoGrid(rq));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEntityAnalysisRequestInfo([FromBody] List<E08T_AnalysisRequest_InfoViewModel> req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_AnalysisRequest_InfoService.UpdateListAnalysisRequestInfo(req);
          
            return Ok(req);
        }
        [HttpPost]
        public async Task<IActionResult> ExportToLab([FromQuery]string requestNo)
        {            
            var date = DateTime.Now;
            string fileNameExport = $"RequestToLab.xlsx";
            string templateDocument = Path.Combine("TemplatesExport", "RequestToLab.xlsx");
            var folder = Path.Combine(_hostingEnvironment.WebRootPath, "export-files");
            string url = $"{Request.Scheme}://{Request.Host}/{"export-files"}/{fileNameExport}";
            var imageFolder = $@"C:\export-files";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            FileInfo file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));
            FileStream fs;
            if (file.Exists)
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport);

                System.IO.File.Delete(path);
                file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));

            }
            using (FileStream templateDocumentStream = System.IO.File.OpenRead(templateDocument))
            {
                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets["RequestToLab"];                  
                    //var result = await _specificationDataService.GetAll();
                    //ViewData["categories"] = result.ToList();
                    var data = new List<SampleManagementReportViewModel>();
                    data = (List<SampleManagementReportViewModel>)await _iSampleManagementReportDapper.GetRequestManagementReport(requestNo.ToString());
                    if (data.Count() > 0) {
                        sheet.Cells[3, 3].Value = data[0].requestNo;
                        sheet.Cells[4, 3].Value = data[0].companyName;
                        sheet.Cells[3, 5].Value = data[0].receivceDate;
                        sheet.Cells[4, 5].Value = data[0].dateOfSendingResult;
                        int rowIndex = 7;
                        int count = 1;
                        int A = 7;
                        int CountData = data.Count();
                        foreach (var item in data)
                        {

                            var coppyFrom = "A7" + ":" + "H7";
                            var coppyTo = "A" + A.ToString() + ":" + "H" + A.ToString();
                            sheet.Cells[coppyFrom].Copy(sheet.Cells[coppyTo]);                            
                            A++;

                            sheet.Cells[rowIndex, 1].Value = count.ToString();
                            //Invoice                       
                            sheet.Cells[rowIndex, 2].Value = item.sampleCode;
                            sheet.Cells[rowIndex, 3].Value = item.specification;
                            sheet.Cells[rowIndex, 4].Value = item.method;
                            sheet.Cells[rowIndex, 5].Value = item.dateOfSendingResult;
                            sheet.Cells[rowIndex, 6].Value = item.result;
                            sheet.Cells[rowIndex, 7].Value = item.Unit;
                            sheet.Cells[rowIndex, 8].Value = item.sampleDescription;

                            rowIndex++;
                            count++;
                        }
                    }
                   
                    sheet.DeleteRow(sheet.Dimension.End.Row);
                    package.SaveAs(file);

                }
            }
            var stream = new MemoryStream();
         
            stream.Position = 0;
            fs = System.IO.File.OpenRead(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));
          
             return File(fs, DRLab.Common.Method.MethodCommon.GetContentType(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport)), fileNameExport);
        
        }
     
       [HttpGet]
        public virtual ActionResult Download(string file)
        {           
            return File("application/vnd.ms-excel", file);
        }
        [HttpPost]
        public async Task<IActionResult> DeletedAnalysisRequestInfo([FromBody] string[] request)
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