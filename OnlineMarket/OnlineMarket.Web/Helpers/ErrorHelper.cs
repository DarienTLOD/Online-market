using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineMarket.Web.Helpers
{
    public static class ErrorHelper
    {
        public static JsonResult Error(IdentityResult result)
        {
            return new JsonResult(new
            {
                errorMesages = result.Errors
                .Select(x => x.Description).ToArray()
            })
            { StatusCode = 400 };
        }

        public static JsonResult Error(ModelStateDictionary modelState)
        {
            return new JsonResult(new
            {
                errorMesages = modelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0).ToArray()
            })
            { StatusCode = 400 };
        }

        public static JsonResult Error(string[] message)
        {
            return new JsonResult(new
            {
                errorMesages = message
            })
            { StatusCode = 400 };
        }
    }
}
