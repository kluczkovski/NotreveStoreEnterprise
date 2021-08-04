using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSE.Web.MVC.Models;

namespace NSE.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.ErrorCode = id;
                modelError.Title = "It has happened an error";
                modelError.Message = "It has happened an erro! Please try again late.";
            }

            if (id == 404)
            {
                modelError.ErrorCode = id;
                modelError.Title = "Ops! Page not found.";
                modelError.Message = "The page that you are looking for does not exit! <br /> Try to contact our support.";
            }

            if (id == 403)
            {
                modelError.ErrorCode = id;
                modelError.Title = "Accesss denied.";
                modelError.Message = "You do not have access this page.";
            }

            return View("Error", modelError);
        }
    }
}
