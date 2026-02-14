using GameZone.ViewModel;

namespace GameZone.services
{
    public interface IGameservice
    {
        Task Create(CreateGamefromviewmodel game);
    }
}
