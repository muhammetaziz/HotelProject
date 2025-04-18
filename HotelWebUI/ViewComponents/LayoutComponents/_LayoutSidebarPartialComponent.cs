using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
