﻿using Microsoft.AspNetCore.Mvc;

namespace HotelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
