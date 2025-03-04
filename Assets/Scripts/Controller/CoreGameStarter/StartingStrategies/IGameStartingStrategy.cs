using System.Threading.Tasks;

namespace Controller.CoreGameStarter.StartingStrategies
{
    public interface IGameStartingStrategy
    {
        Task<bool> TryStartGame();
    }
}
