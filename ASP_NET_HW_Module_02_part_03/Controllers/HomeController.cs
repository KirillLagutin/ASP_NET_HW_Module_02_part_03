using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_HW_Module_02_part_03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
