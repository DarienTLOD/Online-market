using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperationService _operationService;
        private readonly IRatesService _ratesService;
        private readonly IItemsService _itemsService;
        private readonly IAccountService _accountService;

        public HomeController(IOperationService operationService, IRatesService ratesService, IItemsService itemsService, IAccountService accountService)
        {
            _operationService = operationService;
            _ratesService = ratesService;
            _itemsService = itemsService;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
