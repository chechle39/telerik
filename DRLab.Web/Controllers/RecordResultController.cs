using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
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
        private readonly IGenaralData_ReportRepository _genaralData_ReportRepository;
        public RecordResultController(IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, IE08T_WorkingOrder_ItemService e08T_WorkingOrder_ItemService, IHostingEnvironment hostingEnvironment, IFieldAutoTableService fieldAutoTableService, IGenaralData_ReportRepository genaralData_ReportRepository)
        {
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
            _e08T_WorkingOrder_ItemService = e08T_WorkingOrder_ItemService;
            _hostingEnvironment = hostingEnvironment;
            _fieldAutoTableService = fieldAutoTableService;
            _genaralData_ReportRepository = genaralData_ReportRepository;
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
            var rmTb = await _fieldAutoTableService.CreateTable(req);
            if (rmTb)
                await _genaralData_ReportRepository.DeleteDataRP(req[0].SampleCode);
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
            var rubberClassificationNum = await GetExToSave(data.Count(), req[0].requestNo, req[0].DKSVR, req[0].SampleCode);
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

        public async Task<RubberClassificationNum> GetExToSave(int count, string requestNo, string sv, string samcode)
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
                   
                switch(sv)
                {
                    case "L":
                        rowIndex = rowIndex + 0;
                        break;
                    case "3L":
                        rowIndex = rowIndex + 0;
                        break;
                    case "5":
                        rowIndex = rowIndex + 1;
                        break;
                    case "10":
                        rowIndex = rowIndex + 1;
                        break;
                    case "3SD":
                        rowIndex = rowIndex + 1;
                        break;
                    case "CV50":
                        rowIndex = rowIndex + 2;
                        break;
                    case "CV60":
                        rowIndex = rowIndex + 2;
                        break;
                    case "5S":
                        rowIndex = rowIndex + 3;
                        break;
                    case "20":
                        rowIndex = rowIndex + 4;
                        break;
                    default:
                        break;
                }
                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets["PHAN HANG"];
                    sheet.Cells[rowIndex, 3].Calculate();
                    sheet.Cells[rowIndex, 6].Calculate();
                    sheet.Cells[rowIndex, 5].Calculate();
                    sheet.Cells[rowIndex, 4].Calculate();

                    sheet.Cells[rowIndex, 9].Calculate();
                    sheet.Cells[rowIndex, 8].Calculate();
                    sheet.Cells[rowIndex, 7].Calculate();

                    sheet.Cells[rowIndex, 11].Calculate();
                    sheet.Cells[rowIndex, 10].Calculate();

                    sheet.Cells[rowIndex, 13].Calculate();
                    sheet.Cells[rowIndex, 12].Calculate();

                    sheet.Cells[rowIndex, 16].Calculate();
                    sheet.Cells[rowIndex, 15].Calculate();
                    sheet.Cells[rowIndex, 14].Calculate();

                    sheet.Cells[rowIndex, 19].Calculate();
                    sheet.Cells[rowIndex, 18].Calculate();
                    sheet.Cells[rowIndex, 17].Calculate();

                    sheet.Cells[rowIndex, 22].Calculate();
                    sheet.Cells[rowIndex, 21].Calculate();
                    sheet.Cells[rowIndex, 20].Calculate();

                    sheet.Cells[rowIndex, 22].Calculate();
                    sheet.Cells[rowIndex, 23].Calculate();
                    sheet.Cells[rowIndex, 24].Calculate();
                    sheet.Cells[rowIndex, 25].Calculate();
                    var dirt = sheet.Cells[rowIndex, 6].Value == null ? 0 : sheet.Cells[rowIndex, 6].Value;
                    var dirtX = sheet.Cells[rowIndex, 4].Value == null ? 0 : sheet.Cells[rowIndex, 4].Value;
                    var dirtX3S = sheet.Cells[rowIndex, 5].Value == null ? 0 : sheet.Cells[rowIndex, 5].Value;

                    var ash = sheet.Cells[rowIndex, 9].Value == null ? 0 : sheet.Cells[rowIndex, 9].Value;
                    var ashX = sheet.Cells[rowIndex, 7].Value == null ? 0 : sheet.Cells[rowIndex, 7].Value;
                    var ash3S = sheet.Cells[rowIndex, 8].Value == null ? 0 : sheet.Cells[rowIndex, 8].Value;

                    var volatilematter = sheet.Cells[rowIndex,11].Value == null ? 0 : sheet.Cells[rowIndex, 11].Value;
                    var volatilematterMin = sheet.Cells[rowIndex, 10].Value == null ? 0 : sheet.Cells[rowIndex, 10].Value;

                    var nitro = sheet.Cells[rowIndex, 13].Value == null ? 0 : sheet.Cells[rowIndex, 13].Value;
                    var nitroX = sheet.Cells[rowIndex, 12].Value == null ? 0 : sheet.Cells[rowIndex, 12].Value;

                    var po = sheet.Cells[rowIndex, 16].Value == null ? 0 : sheet.Cells[rowIndex, 16].Value;
                    var poMin = sheet.Cells[rowIndex, 14].Value == null ? 0 : sheet.Cells[rowIndex, 14].Value;
                    var poX = sheet.Cells[rowIndex, 15].Value == null ? 0 : sheet.Cells[rowIndex, 15].Value;

                    var pri = sheet.Cells[rowIndex, 19].Value == null ? 0 : sheet.Cells[rowIndex, 19].Value;
                    var priMin = sheet.Cells[rowIndex, 17].Value == null ? 0 : sheet.Cells[rowIndex, 17].Value;
                    var priX = sheet.Cells[rowIndex, 18].Value == null ? 0 : sheet.Cells[rowIndex, 18].Value;

                    var cl = sheet.Cells[rowIndex, 22].Value == null ? 0 : sheet.Cells[rowIndex, 22].Value;
                    var clX = sheet.Cells[rowIndex, 21].Value == null ? 0 : sheet.Cells[rowIndex, 21].Value;
                    var clMin = sheet.Cells[rowIndex, 20].Value == null ? 0 : sheet.Cells[rowIndex, 20].Value;

                    var ml = sheet.Cells[rowIndex, 25].Value == null ? 0 : sheet.Cells[rowIndex, 25].Value;
                    var mlX = sheet.Cells[rowIndex, 24].Value == null ? 0 : sheet.Cells[rowIndex, 24].Value;
                    var mlMin = sheet.Cells[rowIndex, 23].Value == null ? 0 : sheet.Cells[rowIndex, 23].Value;
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
                    var listGenaralData_Report = new List<GeneralData_Report>();
                    var obj1 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "X",
                        specCode = "Dirt",
                        Value = float.Parse(dirtX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj1);
                    var obj2 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "3sd",
                        specCode = "Dirt",
                        Value = float.Parse(dirtX3S.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj2);
                    var obj3 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "Sum",
                        specCode = "Dirt",
                        Value = float.Parse(dirtX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj3);
                    //---------------------------------------------------
                    var obj4 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "X",
                        specCode = "Ash",
                        Value = float.Parse(ashX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj4);
                    var obj5 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "3sd",
                        specCode = "Ash",
                        Value = float.Parse(ash3S.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj5);
                    var obj6 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Sum",
                        specCode = "Ash",
                        Value = float.Parse(ash.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj6);
                    //---------------------------------------------------------------
                    var obj7 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "X",
                        specCode = "Volatile",
                        Value = float.Parse(volatilematterMin.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj7);
                    var obj8 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmax",
                        specCode = "Volatile",
                        Value = float.Parse(volatilematter.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj8);
                    // ----------------------------------------------
                    var obj9 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "X",
                        specCode = "Nito",
                        Value = float.Parse(nitroX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj9);
                    var obj10 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "Xmax",
                        specCode = "Nito",
                        Value = float.Parse(nitro.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj10);
                    //----------------------------------------------------------------------------
                    var obj11 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "Xmin",
                        specCode = "P0",
                        Value = float.Parse(poMin.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj11);
                    var obj12 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "X",
                        specCode = "P0",
                        Value = float.Parse(poX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj12);
                    var obj13 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmax",
                        specCode = "P0",
                        Value = float.Parse(po.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj13);
                    //-----------------------------------------------------------------------------
                    var obj14 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "X",
                        specCode = "PRI",
                        Value = float.Parse(priX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj14);
                    var obj15 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "Xmax",
                        specCode = "PRI",
                        Value = float.Parse(pri.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj15);
                    var obj16 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmin",
                        specCode = "PRI",
                        Value = float.Parse(priMin.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj16);
                    //---------------------------------------------------------------
                    var obj17 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmin",
                        specCode = "Color",
                        Value = float.Parse(clMin.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj17);
                    var obj18 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "X",
                        specCode = "Color",
                        Value = float.Parse(clX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj18);
                    var obj19 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmax",
                        specCode = "Color",
                        Value = float.Parse(cl.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj19);
                    //-------------------------------------------------
                    var obj20 = new GeneralData_Report()
                    {
                      //  ID = 0,
                        Mark = "Xmin",
                        specCode = "ML",
                        Value = float.Parse(mlMin.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj20);
                    var obj21 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "X",
                        specCode = "ML",
                        Value = float.Parse(mlX.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj21);
                    var obj22 = new GeneralData_Report()
                    {
                       // ID = 0,
                        Mark = "Xmax",
                        specCode = "ML",
                        Value = float.Parse(ml.ToString(), CultureInfo.InvariantCulture),
                        requestNo = requestNo,
                        sampleCode = samcode,
                        sampleMatrix = sheet.Cells[rowIndex, 3].Value.ToString(),
                        Rank = sheet.Cells[rowIndex, 3].Value.ToString()
                    };
                    listGenaralData_Report.Add(obj22);
                    await _genaralData_ReportRepository.CreateDataRP(listGenaralData_Report);
                    return rubberClassificationNum;
                }
            }
        }
    }
}