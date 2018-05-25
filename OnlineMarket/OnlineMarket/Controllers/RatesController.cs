using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.Web.Helpers;

namespace OnlineMarket.Web.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : Controller
    {
        private readonly IRatesService _ratesService;

        public RatesController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [AllowAnonymous]
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

                if (result == 0) return ErrorHelper.Error("Nothing changed");

                return Ok();
            }
            catch (Exception exception)
            {
                return ErrorHelper.Error(exception.Message);
            }
        }
    }
}
