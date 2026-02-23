using GameZone.Models;
using GameZone.ViewModel;

namespace GameZone.services
{
    public interface IGameservice
    {
        IEnumerable<Game> Getall();
        Task Create(CreateGamefromviewmodel game);
    }
}
