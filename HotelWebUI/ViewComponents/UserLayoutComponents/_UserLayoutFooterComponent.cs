using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{
    public class _UserLayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
