using GameZone.Data;
using GameZone.services;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {

        private readonly ApplicationDbcontext _context;

        private readonly ICategoriesServices _categoriesServices;
        private readonly IDeviceServices _deviceServices;

        public GamesController(ApplicationDbcontext contrxt,ICategoriesServices x, IDeviceServices deviceServices   )
        {
            _context = contrxt;
            _categoriesServices = x;
            _deviceServices = deviceServices;
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
                Categories = _categoriesServices.GetCategories(),
                Devices = _deviceServices.GetDevices()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGamefromviewmodel model)
        {

            if (!ModelState.IsValid)
            {

                model.Categories = _categoriesServices.GetCategories();
                model.Devices = _deviceServices.GetDevices();
                return View(model);

            }
            //save game to database
            // save cover to server

            return RedirectToAction(nameof(Index));

       
        }


    }
}
