using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.Web.Helpers;
using OnlineMarket.Web.WebSocket;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : Controller
    {
        private readonly IRatesService _ratesService;
        private readonly OnlineMarketWebSocketHandler _handler;

        public RatesController(IRatesService ratesService, OnlineMarketWebSocketHandler handler)
        {
            _ratesService = ratesService;
            _handler = handler;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(await _ratesService.GetCurrentRatesAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<CurrentRateContractModel> rates)
        {
            try
            {
                var result = await _ratesService.ChangeRatesAsync(rates);
                await _handler.SendMessageToAllAsync(JsonConvert.SerializeObject(new {type = "rates", rates}));
                if (result == 0) return ErrorHelper.Error(new[] { "Nothing changed"});

                return Ok();
            }
            catch (Exception exception)
            {
                return ErrorHelper.Error(new[] { exception.Message});
            }
        }
    }
}
