using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NSE.Web.MVC.Extensions
{
    public class SummaryViewComponent: ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
