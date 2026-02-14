using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.services
{
    public interface ICategoriesServices
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
