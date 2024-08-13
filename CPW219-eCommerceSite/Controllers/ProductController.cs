using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get games from database
            List<Product> productList = await (from product in _context.products
                                               select product).ToListAsync();
            // Show then on the page

            return View(productList);
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

        public async Task<IActionResult> Edit(int id)
        {
            Product currentProduct = await _context.products.FindAsync(id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            return View(currentProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                // Add to db
                _context.products.Update(product);
                await _context.SaveChangesAsync();
                // Show message on page
                ViewData["Message"] = $"{product.Name} was updated";
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
