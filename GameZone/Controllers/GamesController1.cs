using GameZone.Data;
using GameZone.services;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {

        private readonly ApplicationDbcontext _context;

        private readonly ICategoriesServices _categoriesServices;
        private readonly IDeviceServices _deviceServices;
        private readonly IGameservice _gameService;

        public GamesController(ApplicationDbcontext contrxt, ICategoriesServices x, IDeviceServices deviceServices, IGameservice gameService)
        {
            _context = contrxt;
            _categoriesServices = x;
            _deviceServices = deviceServices;
            _gameService = gameService;
        }

        public IActionResult Index()
        {

            var game = _gameService.Getall();
            if (game == null)
            {
                throw new Exception("no game");
            }
            return View(game);

        }

        public IActionResult Details(int id)
        {
            var game = _gameService.GetGameById(id);
            return View(game);
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
        public async Task<IActionResult> Create(CreateGamefromviewmodel model)
        {

            if (!ModelState.IsValid)
            {

                model.Categories = _categoriesServices.GetCategories();
                model.Devices = _deviceServices.GetDevices();
                return View(model);

            }

            await _gameService.Create(model);


            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var game = _gameService.GetGameById(id);
            Editviewmodel viewmodl = new()
            {
                id = id,
                Name = game.Name,
                Description = game.Description,
                CategoreyId = game.CategoreyId,
                SelectedDevices = game.Device.Select(d => d.DeviceId).ToList(),

                Categories = _categoriesServices.GetCategories(),
                Devices = _deviceServices.GetDevices(),
                currentcover=game.Cover

            };
            return View(viewmodl);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Editviewmodel model)
        {

            if (!ModelState.IsValid)
            {

                model.Categories = _categoriesServices.GetCategories();
                model.Devices = _deviceServices.GetDevices();
                return View(model);

            }

            var game = await _gameService.update(model);
            if (game is null)
                return BadRequest();
           



            return RedirectToAction(nameof(Index));


        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delet=_gameService.delete(id);

            return delet ? Ok() : BadRequest();
        }


    }
}
