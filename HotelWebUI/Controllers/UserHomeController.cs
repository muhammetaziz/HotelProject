using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
