using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{
    public class _UserLayoutMenuComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
