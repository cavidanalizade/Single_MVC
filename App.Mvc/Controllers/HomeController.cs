using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Mvc.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }

       
    }
}