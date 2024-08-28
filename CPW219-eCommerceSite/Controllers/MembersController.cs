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
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                // Check for existing member in the db
                Member? currMember = (from member in _context.members
                                      where member.Email == registerModel.Email
                                      select member).SingleOrDefault();

                // If member exists, don't make duplicate
                if (currMember != null)
                {
                    // Else, throw an error
                    ModelState.AddModelError("", "User already exists");
                    return RedirectToAction("Index", "Home");
                }

                // Add member to the database
                Member newMember = new()
                {
                    Email = registerModel.Email,
                    Password = registerModel.Password,
                };

                _context.members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");

            }
            return View(registerModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Check for existing member in the db
                Member? currMember = (from  member in _context.members
                                     where member.Email == loginModel.Email &&
                                          member.Password == loginModel.Password
                                     select member).SingleOrDefault();

                // If member exists, send member to home page, logged in
                if (currMember != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                // Else, throw an error
                ModelState.AddModelError("","Login invalid");
            }
            return View(loginModel);
        }
    }
}
