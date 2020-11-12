using Microsoft.AspNetCore.Mvc;
using SarahStore.Models;
namespace SarahStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        //private Cart cart;

        public CartSummaryViewComponent()
        {
            //cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}