using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
