using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Orders.Core.Constant;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {

        protected string UserId;
        protected string Language;

        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(true, "Done", data);
            return response;
        }

        protected async Task<APIResponseViewModel> GetResponse(object data,string message)
        {
            var response = new APIResponseViewModel(true,message, data);
            return response;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (User.Identity.IsAuthenticated)
            {
                UserId = User.FindFirst(Claims.UserId).Value;
            }

            Language = Thread.CurrentThread.CurrentUICulture.Name;
        }

    }
}
