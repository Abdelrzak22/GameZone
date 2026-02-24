using GameZone.Attribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
    public class Editviewmodel
    {
        [MaxLength(2500)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        public int id { get; set; }
        public string? currentcover { get; set; }

        [AllowedExtentions(Filesetting.Allowedextentions)]
        [Maxsize(Filesetting.maxfilesizebyte)]
        public IFormFile? Cover { get; set; } = default!;

        [Display(Name = "category")]
        public int CategoreyId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "support Devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
