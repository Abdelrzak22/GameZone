using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GameZone.services
{
    public class Gameservice : IGameservice
    {

        private readonly ApplicationDbcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagepath;

        public Gameservice(ApplicationDbcontext contrxt, IWebHostEnvironment webHostEnvironment)
        {
            _context = contrxt;
            _webHostEnvironment = webHostEnvironment;
            _imagepath = $"{_webHostEnvironment.WebRootPath}/assests/image/games";
        }

        public IEnumerable<Game> Getall()
        {
            return _context.Games.Include(d=>d.categorey).Include(g=>g.Device).ThenInclude(d=>d.Device).AsNoTracking().ToList();
        }
        public async Task Create(CreateGamefromviewmodel game)
        {
            var CoverName = await savecover(game.Cover);
            Game one = new()
            {
                Name = game.Name,
                Description = game.Description,
                CategoreyId = game.CategoreyId,
                Cover = CoverName,
                Device = game.SelectedDevices.Select(b => new GameDevice { DeviceId = b }).ToList()
            };

            _context.Add(one);
            _context.SaveChanges();

        }

        public Game ? GetGameById(int id)
        {
            return _context.Games.Include(d => d.categorey).Include(g => g.Device).ThenInclude(d => d.Device).AsNoTracking().SingleOrDefault
                (g => g.Id == id);

        }

        public async Task<Game?> update(Editviewmodel model)
        {
            var game = _context.Games.Include(g => g.Device).SingleOrDefault(d => d.Id == model.id);
            var hasnewcover = model.Cover is not null;
            var oldcover = game.Cover;
            if (game is null)
                return null;
            game.Name=model.Name;
            game.Device=model.SelectedDevices.Select(d=>new GameDevice { DeviceId = d }).ToList();
            game.Description=model.Description;
            game.CategoreyId=model.CategoreyId;
            if(hasnewcover)
            {
                game.Cover = await savecover(model.Cover);

            }

            var affectrow = _context.SaveChanges();
            if (affectrow > 0)
            {
                if(hasnewcover)
                {
                    var cover = Path.Combine(_imagepath, oldcover);

                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagepath, game.Cover);

                File.Delete(cover);
                return null;
            }
        }

        private async Task<string> savecover(IFormFile cover)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagepath, CoverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return CoverName ;

        }
    }
}
