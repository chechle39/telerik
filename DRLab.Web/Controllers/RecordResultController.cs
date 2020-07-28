using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class RecordResultController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        private readonly IE08T_WorkingOrder_ItemService _e08T_WorkingOrder_ItemService;
        private readonly IFieldAutoTableService _fieldAutoTableService;
        public RecordResultController(IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, IE08T_WorkingOrder_ItemService e08T_WorkingOrder_ItemService, IHostingEnvironment hostingEnvironment, IFieldAutoTableService fieldAutoTableService)
        {
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
            _e08T_WorkingOrder_ItemService = e08T_WorkingOrder_ItemService;
            _hostingEnvironment = hostingEnvironment;
            _fieldAutoTableService = fieldAutoTableService;
        }
        public async Task<IActionResult> Index(string requestNo)
        {
            var data = await _e08T_AnalysisRequest_InfoService.GetRequestInfoByRequestNo(requestNo);
            var rp = new AnalysisRequest_InfoStringDate()
            {
                requestNo = data.requestNo,
                address = data.address,
                contactID = data.contactID,
                contactName = data.contactName,
                customerCode = data.customerCode,
                customerID = data.customerID,
                dateOfSendingResult = data.dateOfSendingResult.Value.ToString("dd/MM/yyyy hh:mm"),
                email = data.email,
                note = data.note,
                numberSample = data.numberSample,
                receivceDate = data.receivceDate.Value.ToString("dd/MM/yyyy hh:mm"),
            };
            return View(rp);
        }
      
        [HttpGet]
        public async Task<IActionResult> GetRecordResultList(SearchRecordResult rq)
        {
            return Ok(await _e08T_WorkingOrder_ItemService.GetE08TWorkingOrderItemByFkAll(rq));
        }
        [HttpGet]
        public async Task<IActionResult> GetRecordResultDapperList(SearchRecordResult rq)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var converToInt = Int32.Parse(identity.Claims.Where(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")).ToList()[0].Value);
            return Ok(await _e08T_WorkingOrder_ItemService.GetE08TWorkingOrderItemByFkAllDapper(rq, converToInt));
        }
        [HttpGet]
        public async Task<IActionResult> GetRecordResulAccepttList(SearchRecordResult rq)
        {
            return Ok(await _e08T_WorkingOrder_ItemService.GetE08TWorkingOrderItemByFkAllByAccept(rq));
        }
        [HttpGet]
        public async Task<IActionResult> GeFielByCode(string code)
        {
            var data = await _fieldAutoTableService.GetFieldTableByCode(code);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEntity([FromBody]List<RecordResultGridViewModel> req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_WorkingOrder_ItemService.UpdateWorkingOrderItem(req);
            return new OkObjectResult(req);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFieldTable([FromBody] List<FieldAutoTableViewModel> req)
        {
            await _fieldAutoTableService.CreateTable(req);
            // --------------------------------------------------------------------------------
            var data = await _fieldAutoTableService.GetFieldTableByCode(req[0].SampleCode);
            string fileNameExport = $"PhanHang.xlsx";
            string templateDocument = Path.Combine("TemplatesExport", "PhanHang.xlsx");
            var folder = Path.Combine(_hostingEnvironment.WebRootPath, "export-files");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            FileInfo file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "export-files", fileNameExport));
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
                    ExcelWorksheet sheet = package.Workbook.Worksheets["PHAN HANG"];
                    sheet.Cells[3, 7].Value = req[0].SampleCode;
                    sheet.Cells[3, 3].Value = req[0].DKSVR;
                    int rowIndex = 6;
                    int count = 1;
                    int A = 14;
                    if (data.Count() > 10)
                    {
                        sheet.InsertRow(15, data.Count()-7);
                    }
                    for (int i = 0; i< data.Count()-7;i++)
                    {
                        var coppyFrom = "A13" + ":" + "Q13";
                        var coppyTo = "A" + A.ToString() + ":" + "Q" + A.ToString();
                        sheet.Cells[coppyFrom].Copy(sheet.Cells[coppyTo]);
                        A++;
                    }
                    foreach (var item in data)
                    {
                        if (count > 13)
                        {
                            sheet.Cells[rowIndex, 1].Value = count.ToString();
                            sheet.Cells[rowIndex, 2].Value = decimal.Parse(item.Dirt, CultureInfo.InvariantCulture);
                            sheet.Cells[rowIndex, 3].Value = decimal.Parse(item.Ash);
                            sheet.Cells[rowIndex, 4].Value = decimal.Parse(item.Volatilematter);
                            sheet.Cells[rowIndex, 5].Value = decimal.Parse(item.Nitro);
                            sheet.Cells[rowIndex, 6].Value = decimal.Parse(item.P0);
                            sheet.Cells[rowIndex, 7].Value = decimal.Parse(item.PRI);
                            sheet.Cells[rowIndex, 8].Value = decimal.Parse(item.Color);
                            sheet.Cells[rowIndex, 9].Value = decimal.Parse(item.ML);
                            sheet.Cells[rowIndex, 11].Value = decimal.Parse(item.Dirt) * decimal.Parse(item.Dirt);
                            sheet.Cells[rowIndex, 12].Value = decimal.Parse(item.Ash) * decimal.Parse(item.Ash);
                            A++;
                        }
                        else
                        {
                            sheet.Cells[rowIndex, 1].Value = count.ToString();
                            sheet.Cells[rowIndex, 2].Value = decimal.Parse(item.Dirt, CultureInfo.InvariantCulture);
                            sheet.Cells[rowIndex, 3].Value = decimal.Parse(item.Ash);
                            sheet.Cells[rowIndex, 4].Value = decimal.Parse(item.Volatilematter);
                            sheet.Cells[rowIndex, 5].Value = decimal.Parse(item.Nitro);
                            sheet.Cells[rowIndex, 6].Value = decimal.Parse(item.P0);
                            sheet.Cells[rowIndex, 7].Value = decimal.Parse(item.PRI);
                            sheet.Cells[rowIndex, 8].Value = decimal.Parse(item.Color);
                            sheet.Cells[rowIndex, 9].Value = decimal.Parse(item.ML);
                        }
                        rowIndex++;
                        count++;

                    }
                    for (int i = 0; i <= (((data.Count() + 6) + 2) - ((data.Count() + 6))); i++)
                    {
                        sheet.DeleteRow(((data.Count() + 6)) + i);
                    }
                    package.SaveAs(file);
                   
                }
            }
            var rubberClassificationNum = GetExToSave(data.Count());
            return Ok(rubberClassificationNum);
        }
        
        public async Task<IActionResult> RiviewRequest(string requestNo)
        {
            var data = await _e08T_AnalysisRequest_InfoService.GetRequestInfoByRequestNo(requestNo);
            var rp = new AnalysisRequest_InfoStringDate()
            {
                requestNo = data.requestNo,
                address = data.address,
                contactID = data.contactID,
                contactName = data.contactName,
                customerCode = data.customerCode,
                customerID = data.customerID,
                dateOfSendingResult = data.dateOfSendingResult.Value.ToString("dd/MM/yyyy hh:mm"),
                email = data.email,
                note = data.note,
                numberSample = data.numberSample,
                receivceDate = data.receivceDate.Value.ToString("dd/MM/yyyy hh:mm"),
            };
            return View(rp);
        }

        public async Task<IActionResult> ApproveResult(string requestNo)
        {
            var data = await _e08T_AnalysisRequest_InfoService.GetRequestInfoByRequestNo(requestNo);
            var rp = new AnalysisRequest_InfoStringDate()
            {
                requestNo = data.requestNo,
                address = data.address,
                contactID = data.contactID,
                contactName = data.contactName,
                customerCode = data.customerCode,
                customerID = data.customerID,
                dateOfSendingResult = data.dateOfSendingResult.Value.ToString("dd/MM/yyyy hh:mm"),
                email = data.email,
                note = data.note,
                numberSample = data.numberSample,
                receivceDate = data.receivceDate.Value.ToString("dd/MM/yyyy hh:mm"),
            };
            return View(rp);
        }

        public RubberClassificationNum GetExToSave(int count)
        {
            string fileNameExport = $"PhanHang.xlsx";
            string templateDocument = Path.Combine(_hostingEnvironment.WebRootPath, "export-files", "PhanHang.xlsx");
            using (FileStream templateDocumentStream = System.IO.File.OpenRead(templateDocument))
            {
                int rowIndex = 0;
                if (count > 13)
                {
                    rowIndex = count + 10;
                } else
                {
                    rowIndex = 17;
                }
                   
                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets["PHAN HANG"];
                    sheet.Cells[rowIndex, 6].Calculate();
                    sheet.Cells[rowIndex, 9].Calculate();
                    sheet.Cells[rowIndex, 11].Calculate();
                    sheet.Cells[rowIndex, 13].Calculate();
                    sheet.Cells[rowIndex, 16].Calculate();
                    sheet.Cells[rowIndex, 19].Calculate();
                    sheet.Cells[rowIndex, 22].Calculate();
                    sheet.Cells[rowIndex, 22].Calculate();
                    sheet.Cells[rowIndex, 25].Calculate();
                    var dirt = sheet.Cells[rowIndex, 6].Value == null ? 0 : sheet.Cells[rowIndex, 6].Value;
                    var ash = sheet.Cells[rowIndex, 9].Value == null ? 0 : sheet.Cells[rowIndex, 9].Value;
                    var volatilematter = sheet.Cells[rowIndex,11].Value == null ? 0 : sheet.Cells[rowIndex, 11].Value;
                    var nitro = sheet.Cells[rowIndex, 13].Value == null ? 0 : sheet.Cells[rowIndex, 13].Value;
                    var po = sheet.Cells[rowIndex, 16].Value == null ? 0 : sheet.Cells[rowIndex, 16].Value;
                    var pri = sheet.Cells[rowIndex, 19].Value == null ? 0 : sheet.Cells[rowIndex, 19].Value;
                    var cl = sheet.Cells[rowIndex, 22].Value == null ? 0 : sheet.Cells[rowIndex, 22].Value;
                    var ml = sheet.Cells[rowIndex, 25].Value == null ? 0 : sheet.Cells[rowIndex, 25].Value;
                    var rubberClassificationNum = new RubberClassificationNum()
                    {
                        Dirt = decimal.Parse(dirt.ToString(), CultureInfo.InvariantCulture),
                        Ash = decimal.Parse(ash.ToString(), CultureInfo.InvariantCulture),
                        Volatilematter = decimal.Parse(volatilematter.ToString(), CultureInfo.InvariantCulture),
                        Nitro = decimal.Parse(nitro.ToString(), CultureInfo.InvariantCulture),
                        P0 = decimal.Parse(po.ToString(), CultureInfo.InvariantCulture),
                        PRI = decimal.Parse(pri.ToString(), CultureInfo.InvariantCulture),
                        Color = decimal.Parse(cl.ToString(), CultureInfo.InvariantCulture),
                        ML = decimal.Parse(ml.ToString(), CultureInfo.InvariantCulture)
                    };
                    return rubberClassificationNum;
                }
            }
        }
    }
}