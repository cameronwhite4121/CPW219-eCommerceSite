using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class MembersController : Controller
    {

        private readonly ProductContext _context;
        public MembersController(ProductContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel m)
        {
            if (ModelState.IsValid)
            {
                // Add member to the database
                Member newMember = new()
                {
                    Email = m.Email,
                    Password = m.Password,
                };

                _context.members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(m);
        }
    }
}
