using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;


        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("/GetList")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserRoles()
        {
            return new JsonResult(await _roleManager.Roles.ToListAsync());
        }
    }
}