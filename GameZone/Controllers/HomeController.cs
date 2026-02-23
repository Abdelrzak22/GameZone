using System.Diagnostics;
using GameZone.Models;
using GameZone.services;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameservice _game;

        public HomeController(IGameservice game)
        {
            _game = game;
        }

        public IActionResult Index()
        {

            var game = _game.Getall();
            if (game == null)
            {
                throw new Exception("no game");
            }
            return View(game);

        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
