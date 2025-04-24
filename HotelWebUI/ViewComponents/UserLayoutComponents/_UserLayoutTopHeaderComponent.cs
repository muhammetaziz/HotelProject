using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{
    public class _UserLayoutTopHeaderComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
