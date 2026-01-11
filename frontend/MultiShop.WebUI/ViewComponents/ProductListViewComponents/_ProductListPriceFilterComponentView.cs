using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPriceFilterComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
