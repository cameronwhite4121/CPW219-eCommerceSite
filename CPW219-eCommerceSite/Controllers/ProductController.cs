using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context) 
        {
            _context = context;
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                // Add to db
                _context.products.Add(product);
                await _context.SaveChangesAsync();
                // Show message on page
                ViewData["Message"] = $"{product.Name} was added";
                return View();
            }
            
            return View(product);
        }
    }
}
