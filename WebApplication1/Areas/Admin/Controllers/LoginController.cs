using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private readonly HarmicContext _context;

        public LoginController(HarmicContext context)
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
            var check = _context.AdminUsers.Where(m => (m.UserName == user.UserName) && (m.Password == user.Password)).FirstOrDefault();

            if (check == null)
            {
                Function._Message = "Thông báo có kẻ xâm nhập hệ thống  ";
                return RedirectToAction("Index", "Login");
            }
            // vào trang Admin nếu đúng user và pass
            Function._Message = string.Empty;
            Function._UserId = check.UserId;
            Function._UserName = string.IsNullOrEmpty(check.UserName)? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email)? string.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
