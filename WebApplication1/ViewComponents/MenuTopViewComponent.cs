using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        public readonly HarmicContext _context; // giao tiếp với csdl _context: cho phép truy vấn dữ liệu 
        public MenuTopViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool IsActive)
        {
            var items = _context.TblMenus. // truy vấn bg Menus từ csdl thông qua Entity
                Where(m => m.IsActive.HasValue && m.IsActive.Value).// chỉ chọn menu có IsActive là true, chọ các mục menu đg hd
                OrderBy(m => m.Position).//sx menu theo cột 
                ToList();//chuyên kq truy vấn thành 1 ds bất đồng độ 
            return await Task.FromResult<IViewComponentResult>(View(items));// trả về ds các menu hd
        }
    }
}
