using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
