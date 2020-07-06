using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
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
    }
}