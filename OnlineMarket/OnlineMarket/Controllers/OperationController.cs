using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class OperationController : Controller
    {
        [Authorize(Policy = "Member")]
        public IActionResult Get()
        {
            return new JsonResult(new {Meow = "meow"});
        }
    }
}
