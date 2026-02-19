using Microsoft.AspNetCore.Mvc.Rendering;
using GameZone.Attribute;
using GameZone.Setting;
using System.ComponentModel.DataAnnotations;

using System.Runtime.CompilerServices;

namespace GameZone.ViewModel
{
    public class CreateGamefromviewmodel
    {

        [MaxLength(2500)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;


        [AllowedExtentions(Filesetting.Allowedextentions)]
        [Maxsize(Filesetting.maxfilesizebyte)]
        public IFormFile Cover { get; set; } = default!;

        [Display(Name ="category")]
        public int CategoreyId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name="support Devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
