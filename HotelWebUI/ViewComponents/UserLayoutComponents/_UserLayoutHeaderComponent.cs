using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{
    public class _UserLayoutHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
