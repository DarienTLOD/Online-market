using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineMarket.Web.Infrastructure;
using OnlineMarket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.Web.Extensions;
using OnlineMarket.Web.Helpers;

namespace OnlineMarket.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<UserContractModel> _userManager;
        private readonly SignInManager<UserContractModel> _signInManager;
        private readonly JwtSettings _settings;
        private readonly DefaultNewUserRoleOptions _defaultRole;
        private readonly IEmailSender _emailSender;

        public AccountController(
          UserManager<UserContractModel> userManager,
          SignInManager<UserContractModel> signInManager,
          IOptions<JwtSettings> optionsAccessor,
          IOptions<DefaultNewUserRoleOptions> defaultRole,
          IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _defaultRole = defaultRole.Value;
            _settings = optionsAccessor.Value;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserCredentials credentials)
        {
            if (!ModelState.IsValid) return ErrorHelper.Error(ModelState);

            var user = new UserContractModel { UserName = credentials.Email, Email = credentials.Email };
            var result = await _userManager.CreateAsync(user, credentials.Password);

            if (!result.Succeeded) return ErrorHelper.Error(result);

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);

            _emailSender.SendEmailConfirmationAsync(credentials.Email, callbackUrl);
            result = await _userManager.AddToRoleAsync(user, _defaultRole.Role);

            if (!result.Succeeded) return ErrorHelper.Error(result);

            return Ok("Account confirmation is required.");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserCredentials credentials)
        {
            if (!ModelState.IsValid) return ErrorHelper.Error(ModelState);

            var user = await _userManager.FindByEmailAsync(credentials.Email);

            if (user == null) return ErrorHelper.Error(new[] { "The user with email doesn't exist."});
            if (!await _userManager.IsEmailConfirmedAsync(user)) return ErrorHelper.Error(new[] { "Account confirmation is required."});

            var result = await _signInManager.PasswordSignInAsync(user, credentials.Password, credentials.IsPersistent, false);

            if (!result.Succeeded) return ErrorHelper.Error(new []{"Error login user."});

            return new JsonResult(new { accessToken = new JwtTokenBuilder(_settings).Build(user.Email, _defaultRole.Role, user.Id), userName = credentials.Email });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return ErrorHelper.Error(new[] { "Error confirming email."});
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ErrorHelper.Error(new[] { $"Unable to load user with ID '{userId}'."});
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                return ErrorHelper.Error(new[] { $"Error confirming email for user with ID '{userId}':"});
            }

            return Ok();
        }
    }
}
