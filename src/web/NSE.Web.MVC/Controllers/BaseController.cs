using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NSE.Web.MVC.Models;

namespace NSE.Web.MVC.Controllers
{
    public class BaseController : Controller
    {

        protected bool ResponseHasErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                foreach (var mesasge in response.Errors.Messages)
                {
                    ModelState.AddModelError(string.Empty, mesasge);
                }
                return true;
            }

            return false;
        }
    }
}
