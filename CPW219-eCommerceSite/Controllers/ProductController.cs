using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create() 
        {
            return View();
        }
    }
}
