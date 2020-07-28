using DRLab.Data.Identity;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        public UserController(IUserService userService,  UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetAllUser());
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity([FromBody]ApplicationUserViewModel userVm)
        {

            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            var saveEntity = await _userService.AddAsync(userVm);
            if (saveEntity == true)
            {
                return Ok(userVm);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int[] id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                await _userService.DeleteAsync(id);

                return Ok(true);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _userService.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEntity([FromBody] ApplicationUserViewModel userVm)
        {

            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _userService.UpdateAsync(userVm);
            return Ok(userVm);
        }
    }
}
