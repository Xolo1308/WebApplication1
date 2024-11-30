using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly HarmicContext _context;
        public RegisterController(HarmicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null) 
                {
                return NotFound();
                }
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null) 
            {
                Function._MessageEmail = "Duplicate Email";
                return RedirectToAction("Index", "Register");
            }
            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");

        }
    }
}
