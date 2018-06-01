using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Web.Helpers;
using OnlineMarket.Web.Models;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<UserContractModel> _userManager;

        public UserController(UserManager<UserContractModel> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetList(int page = 1, int pageSize = 20)
        {
            var count = await _userManager.Users.CountAsync();
            var data = await _userManager.Users.Select(x => new { x.Id, UserName = x.Email, IsLockout = x.LockoutEnabled, IsEmailConfirmed = x.EmailConfirmed })
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new JsonResult(new {data, itemsCount = count});
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeUserLockout([FromBody] UserLockoutModel lockoutModel)
        {
            if (!ModelState.IsValid) return ErrorHelper.Error(ModelState);

            var user = await _userManager.FindByIdAsync(lockoutModel.UserId);
            if (user == null)
            {
                return ErrorHelper.Error(new[] { $"Unable to load user with ID '{lockoutModel.UserId}'."});
            }

            var result = await _userManager.SetLockoutEnabledAsync(user, lockoutModel.IsLockout);

            if (!result.Succeeded)
            {
                return ErrorHelper.Error(result);
            }

            return Ok(new { user.Id, UserName = user.Email, IsLockout = user.LockoutEnabled, IsEmailConfirmed = user.EmailConfirmed });
        }
    }
}
