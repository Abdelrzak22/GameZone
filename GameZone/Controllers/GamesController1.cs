using GameZone.Data;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {

        private readonly ApplicationDbcontext _context;

        public GamesController(ApplicationDbcontext contrxt)
        {
            _context = contrxt;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Create()
        {

            CreateGamefromviewmodel viewmodel = new()
            {
                Categories = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text).ToList(),
                Devices =_context.Categories.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).OrderBy(x => x.Text).ToList()
            };

            return View(viewmodel);
        }


    }
}
