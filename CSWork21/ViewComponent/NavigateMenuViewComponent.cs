using Microsoft.AspNetCore.Mvc;

namespace CSWork21.Component
{
    public class NavigateMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
