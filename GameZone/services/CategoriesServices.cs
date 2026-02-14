using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.services
{
    public class CategoriesServices : ICategoriesServices
    {

        private readonly ApplicationDbcontext _context;

        public CategoriesServices(ApplicationDbcontext contrxt)
        {
            _context = contrxt;
        }
        public IEnumerable<SelectListItem> GetCategories()
        {
          return _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text).ToList();
        }
    }
}
