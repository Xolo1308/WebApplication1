using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {

        private readonly HarmicContext _context;

        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblBlogs.Include(m => m.Category)
           .Where(m => m.IsActive == true);

            return View(await items.OrderBy(m => m.BlogId).ToListAsync());

        }

    }
}
