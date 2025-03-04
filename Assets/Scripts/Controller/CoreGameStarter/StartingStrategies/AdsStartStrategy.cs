using System.Threading.Tasks;
using Controller.AdsSystem;
using JetBrains.Annotations;
using Zenject;

namespace Controller.CoreGameStarter.StartingStrategies
{
    [UsedImplicitly]
    public class AdsStartStrategy : IGameStartingStrategy
    {
        [Inject] private readonly IAdsSystem adsSystem;
        
        public async Task<bool> TryStartGame()
        {
            if (await adsSystem.ShowAd())
            {
                return true;
            }

            return false;
        }
    }
}
