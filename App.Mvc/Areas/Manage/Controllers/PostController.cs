using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
