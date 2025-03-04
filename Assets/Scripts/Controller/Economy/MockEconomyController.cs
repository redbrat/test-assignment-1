using JetBrains.Annotations;

namespace Controller.Economy
{
    [UsedImplicitly]
    public class MockEconomyController : IEconomyController
    {
        public bool HaveFreeGames()
        {
            return true;
        }

        public bool HaveEnoughCoinsForGame()
        {
            return true;
        }

        public void ChargeCoinsForOneGame()
        {
        }
    }
}
