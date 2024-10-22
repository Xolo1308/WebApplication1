using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly HarmicContext _context;
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(HarmicContext context ,ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.productCategories = _context.TblProductCategories.ToList();
            ViewBag.productNew = _context.TblProducts.Where(m => (bool)m.IsNew).ToList();
            return View();
        }

      
    }
}
