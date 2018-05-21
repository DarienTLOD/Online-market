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
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public HomeController(IOperationService operationService, IRatesService ratesService, IItemsService itemsService, IUserService userService, IAccountService accountService)
        {
            _operationService = operationService;
            _ratesService = ratesService;
            _itemsService = itemsService;
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult Index()
        {

            var items = _itemsService.GetItems();
            var rates = _ratesService.GetCurrentRates();
            var user = _userService.GetAll().FirstOrDefault();
            var account = _accountService.GetAccountByAccountOwnerId(user.Id);

            rates.ForEach(x=>x.Rate = 30);

            _ratesService.ChangeRates(rates);

            _operationService.BuyItems(new OperationContractModel
            {
                Items = new List<OperationItemContactModel>()
                {
                    new OperationItemContactModel{ItemTypeId = items.First().Id, Quantity = 5 }
                }, UserAccountId = account.Id,
                UserId = user.Id
            });
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
