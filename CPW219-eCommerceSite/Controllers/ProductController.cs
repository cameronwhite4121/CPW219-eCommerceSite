﻿using CPW219_eCommerceSite.Data;
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
                TempData["Message"] = $"{product.Name} was updated";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product currentProduct = await _context.products.FindAsync(id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            return View(currentProduct);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find product that matches id
            Product product = await _context.products.FindAsync(id);

            if (product != null)
            {
                // Add to db
                _context.products.Remove(product);
                await _context.SaveChangesAsync();

                // Show message on page
                TempData["Message"] = $"{product.Name} was deleted";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "Game was already deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Product product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); 
            }

            return View(product);
        }
    }
}
