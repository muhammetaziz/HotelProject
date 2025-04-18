using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
