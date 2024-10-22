using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {

        private readonly HarmicContext _context;

        public ProductViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblProducts.Include(m => m.CategoryProduct)
           .Where(m => m.IsActive == true)
           .Where(m => m.IsNew == true);

            return View(await items.OrderBy(m => m.ProductId).ToListAsync());
        }
    }


}
