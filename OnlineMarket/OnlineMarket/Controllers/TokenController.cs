using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineMarket.Web.Infrastructure;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly JwtSettings _options;

        public TokenController(IOptions<JwtSettings> options)
        {
            _options = options.Value;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            var token = new JwtTokenBuilder(_options).Build("Meowka","Admen");

            return Ok(token.Value);
        }

        [HttpPost]
        [Authorize(Roles = "Odmen")]
        public IActionResult CreateFuck()
        {
            return Ok("Meow");
        }
    }
}
