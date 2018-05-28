using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.Web.WebSocket;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class OperationController : Controller
    {
        private readonly OnlineMarketWebSocketHandler _handler;
        private readonly IOperationService _operationService;
        public OperationController(OnlineMarketWebSocketHandler handler, IOperationService operationService)
        {
            _handler = handler;
            _operationService = operationService;
        }

        public IActionResult Get()
        {
            return new JsonResult(new {Meow = "meow"});
        }
    }
}
