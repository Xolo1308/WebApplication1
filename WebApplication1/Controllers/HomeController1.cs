using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Diagnostics;


namespace WebApplication1.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly HarmicContext _context;

        public HomeController1(HarmicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }
            var product = await _context.TblProducts.Include(i => i.CategoryProduct).FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)

            {
               return  NotFound();
            }
            ViewBag.productReView = _context.TblProductReviews
                    .Where(i => i.ProductId == id && (bool)i.IsActive).ToList();
            ViewBag.productRelated = _context.TblProducts
            .Where(predicate: i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).OrderByDescending(i => i.ProductId).Take(10).ToList();
            return View(product);
        }
    }
}
