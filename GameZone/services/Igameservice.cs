using GameZone.Models;
using GameZone.ViewModel;

namespace GameZone.services
{
    public interface IGameservice
    {
        IEnumerable<Game> Getall();

        Game GetGameById(int id);
        Task Create(CreateGamefromviewmodel game);
        Task<Game?> update(Editviewmodel model);
        bool delete(int id);
    }
}
