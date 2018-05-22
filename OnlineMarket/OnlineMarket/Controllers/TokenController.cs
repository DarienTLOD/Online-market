using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Web.Helpers;
using OnlineMarket.Web.Infrastructure;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private readonly JwtSettings _options;

        public TokenController(IOptions<JwtSettings> options)
        {
            _options = options.Value;
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserContractModel inputModel)
        {
            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(_options.SecretKey))
                .AddSubject("james bond")
                .AddIssuer(_options.Issuer)
                .AddAudience(_options.Audience)
                .AddClaim("MembershipId", "111")
                .AddExpiry(60)
                .Build();

            return Ok(token.Value);
        }
    }
}
