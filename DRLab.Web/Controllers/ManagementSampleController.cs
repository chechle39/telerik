using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class ManagementSampleController : Controller
    {
        private readonly IE00T_CustomerService _customerService;
        private readonly ISampleManagementDapperService _sampleManagementDapperService;
        private readonly ISampleManagementReportDapper _sampleManagementReportDapper;
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        private readonly IE08T_AnalysisRequest_ItemService _iE08T_AnalysisRequest_ItemService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ManagementSampleController(ISampleManagementReportDapper sampleManagementReportDapper, IE00T_CustomerService customerService, IE08T_AnalysisRequest_ItemService iE08T_AnalysisRequest_ItemService, IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, ISampleManagementDapperService sampleManagementDapperService, IHostingEnvironment hostingEnvironment)
        {
            _sampleManagementReportDapper = sampleManagementReportDapper;
            _customerService = customerService;
            _iE08T_AnalysisRequest_ItemService = iE08T_AnalysisRequest_ItemService;
            _sampleManagementDapperService = sampleManagementDapperService;
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
        public async Task<IActionResult> GetManagementSampleList(SerchSampleManagement rq)
        {
            return Ok(await _sampleManagementDapperService.GetSampleManagement(rq));
        }
        [HttpPost]
        public async Task<IActionResult> ExportManagementSample([FromBody] SerchSampleManagement rq)
        {
            var date = DateTime.Now;
            string fileNameExport = $"Phan_Hang.xlsx";
            string templateDocument = Path.Combine("TemplatesExport", "Phan_Hang.xlsx");
            var folder = Path.Combine(_hostingEnvironment.WebRootPath, "export-files");
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
                    ExcelWorksheet sheet = package.Workbook.Worksheets["SO LIEU"];
                    var data = new List<SampleManagementExportViewModel>();
                    data = (List<SampleManagementExportViewModel>)await _sampleManagementDapperService.GetSampleManagementExport(rq);

                

                    int rowIndex = 7;
                    int count = 1;
                    int A = 7;
                    int CountData = data.Count();
                    if (data.Count() > 0) {
                        foreach (var item in data)
                        {

                            var coppyFrom = "A7" + ":" + "AA7";
                            var coppyTo = "A" + A.ToString() + ":" + "AA" + A.ToString();
                            sheet.Cells[coppyFrom].Copy(sheet.Cells[coppyTo]);
                            A++;
                          
                            if (rowIndex==7 || sheet.Cells[rowIndex, 1].Value != sheet.Cells[rowIndex - 1, 1].Value)
                            {
                                sheet.Cells[rowIndex, 1].Value = ((DateTime)item.receivceDate).ToString("dd/MM/yyyy");
                            }
                            sheet.Cells[rowIndex, 2].Value = item.requestNo;
                            sheet.Cells[rowIndex, 3].Value = item.sampleCode;
                            sheet.Cells[rowIndex, 4].Value = item.sampleMatrix;                           
                            sheet.Cells[rowIndex, 5].Value = item.DirtX;
                            sheet.Cells[rowIndex, 6].Value = item.Dirt3sd;
                            sheet.Cells[rowIndex, 7].Value = item.DirtSum;                            
                            sheet.Cells[rowIndex, 8].Value = item.AshX;
                            sheet.Cells[rowIndex, 9].Value = item.Ash3sd;
                            sheet.Cells[rowIndex, 10].Value = item.AshSum;
                            sheet.Cells[rowIndex, 11].Value = item.VolatileX;
                            sheet.Cells[rowIndex, 12].Value = item.VolatileXmax;
                            sheet.Cells[rowIndex, 13].Value = item.NitoX;
                            sheet.Cells[rowIndex, 14].Value = item.NitoXmax;
                            sheet.Cells[rowIndex, 15].Value = item.P0Xmin;
                            sheet.Cells[rowIndex, 16].Value = item.P0X;
                            sheet.Cells[rowIndex, 17].Value = item.P0Xmax;
                            sheet.Cells[rowIndex, 18].Value = item.PRIXmin;
                            sheet.Cells[rowIndex, 19].Value = item.PRIX;
                            sheet.Cells[rowIndex, 20].Value = item.PRIXmax;
                            sheet.Cells[rowIndex, 21].Value = item.ColorXmin;
                            sheet.Cells[rowIndex, 22].Value = item.ColorX;
                            sheet.Cells[rowIndex, 23].Value = item.ColorXmax;
                            sheet.Cells[rowIndex, 24].Value = item.MLX;
                            sheet.Cells[rowIndex, 25].Value = item.MLXmin;
                            sheet.Cells[rowIndex, 26].Value = item.MLXmax;
                            sheet.Cells[rowIndex, 27].Value = item.Rank;
                            rowIndex++;
                            count++;
                        }
                     
                        package.SaveAs(file);
                    }
                

                }
            }
            var stream = new MemoryStream();

            stream.Position = 0;
            fs = System.IO.File.OpenRead(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));

            return File(fs, DRLab.Common.Method.MethodCommon.GetContentType(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport)), fileNameExport);

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
        [HttpGet]
        public async Task<IActionResult> GetDataReport(string requestNo)
        {
            return Ok(await _iE08T_AnalysisRequest_ItemService.GetAnalysisByRequestNo(requestNo));
        }
        [HttpPost]
        public async Task<IActionResult> PrintManagementSample([FromQuery] string requestNo)
        {
           
            var date = DateTime.Now;
            string fileNameExport = $"TestingReport.xlsx";
            string templateDocument = Path.Combine("TemplatesExport", "TestingReport.xlsx");
            var folder = Path.Combine(_hostingEnvironment.WebRootPath, "export-files");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            FileInfo file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));
            FileStream fs;
            int No = 1;
            if (file.Exists)
            {            
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport);
                using (FileStream temp = System.IO.File.OpenRead(path))
                {
                    using (ExcelPackage package = new ExcelPackage(temp))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets["TestingReport"];
                        if (worksheet.Cells[15, 14].Value != null) {
                            int tempNo = Int32.Parse(worksheet.Cells[15, 14].Value.ToString());
                            if (tempNo != null)
                            {
                                No = tempNo + 1;
                            }
                        }
                      
                    }
                }
                System.IO.File.Exists(path);
                System.IO.File.Delete(path);
                file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));

            }
            using (FileStream templateDocumentStream = System.IO.File.OpenRead(templateDocument))
            {
               

                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets["TestingReport"];
                    var data = new List<SampleManagementExportViewModel>();
                    data = (List<SampleManagementExportViewModel>)await _sampleManagementReportDapper.GetSampleManagementReport(requestNo);
                  
                    var sa = sheet.Cells[15, 1].Value;
                    string sampleName = "";
                    int rowIndex = 21;
                    int A = 21;
                    int B =5;
                    int CountData = data.Count();
                    sheet.Cells[15, 14].Value = No;
                    sheet.Cells[15, 12].Value = No.ToString() + '/' + date.ToString("MM") + '/' + data[0].contactName;
                    sheet.Cells[17,12].Value = date.ToString("MM/dd/yyyy");                 
                    sheet.Cells[19, 9].Value = data[0].sampleMatrix;                    

                    for (int i = 0; i < data.Count(); i++)
                    {
                        var coppyFrom = "A21" + ":" + "P21";
                        var coppyTo = "A" + A.ToString() + 1 + ":" + "P" + A.ToString() + 1;
                        sheet.Cells[coppyFrom].Copy(sheet.Cells[coppyTo]);
                        sampleName = sampleName + data[i].sampleCode + ',' + "  "; 
                        A = A + 2;
                     
                        sheet.Cells[20, B].Value = data[i].sampleCode;                       
                        sheet.Cells[21, B].Value = data[i].DirtSum;
                        sheet.Cells[23, B].Value = data[i].AshSum;
                        sheet.Cells[25, B].Value = data[i].VolatileXmax;
                        sheet.Cells[27, B].Value = data[i].NitoXmax;                        
                        sheet.Cells[29, B].Value = Math.Round((data[i].P0X));
                        sheet.Cells[29, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[30, B].Value = data[i].P0Xmin.ToString() + "   " + data[i].P0Xmax.ToString(); ;
                        sheet.Cells[30, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[31, B].Value = Math.Round((data[i].PRIX));
                        sheet.Cells[31, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[32, B].Value = data[i].PRIXmin.ToString() + "   " + data[i].PRIXmax.ToString(); ;
                        sheet.Cells[32, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[33, B].Value = Math.Round((data[i].MLX));
                        sheet.Cells[33, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[34, B].Value = data[i].MLXmin.ToString() + "   " + data[i].MLXmax.ToString(); ;
                        sheet.Cells[34, B].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        B += 1;
                    }
                    
                    sheet.Cells["G37"].Value = sheet.Cells["D16"].Value = sampleName;
                    //sheet.DeleteRow(sheet.Dimension.End.Row);
                    package.SaveAs(file);

                }
            }
            var stream = new MemoryStream();

            stream.Position = 0;
            fs = System.IO.File.OpenRead(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));

            return File(fs, DRLab.Common.Method.MethodCommon.GetContentType(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport)), fileNameExport);

        }

    }
}