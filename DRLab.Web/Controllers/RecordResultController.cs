using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class RecordResultController : Controller
    {
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        private readonly IE08T_WorkingOrder_ItemService _e08T_WorkingOrder_ItemService;
        public RecordResultController(IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService, IE08T_WorkingOrder_ItemService e08T_WorkingOrder_ItemService)
        {
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
            _e08T_WorkingOrder_ItemService = e08T_WorkingOrder_ItemService;
        }
        public async Task<IActionResult> Index(string from, string to, string requestNo)
        {
            //var result = await _specificationDataService.GetAll();
            //ViewData["categories"] = result.ToList();
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
    }
}