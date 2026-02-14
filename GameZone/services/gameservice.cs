using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModel;

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
        public async Task Create(CreateGamefromviewmodel game)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(game.Cover.FileName)}";
            var path=Path.Combine(_imagepath, CoverName);
            using var stream=File.Create(path);
            await game.Cover.CopyToAsync(stream);

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
    }
}
