using System.Threading.Tasks;
using Controller.Economy;
using JetBrains.Annotations;
using Zenject;

namespace Controller.CoreGameStarter.StartingStrategies
{
    [UsedImplicitly]
    public class FreeStartStrategy : IGameStartingStrategy
    {
        [Inject] private readonly IEconomyController economyController;
        
        public Task<bool> TryStartGame()
        {
            if (economyController.HaveFreeGames())
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
