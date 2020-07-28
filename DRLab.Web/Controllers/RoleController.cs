using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DRLab.Web.Controllers
{

    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRole(string text)
        {
            return Ok(await _roleService.GetAllAsync(text));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoleCbb()
        {
            return Ok(await _roleService.GetAllAsync(""));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole([FromBody] ApplicationRoleViewModel roleVm)
        {
            await _roleService.AddAsync(roleVm);
            return Ok(roleVm);
        }
    }
}
