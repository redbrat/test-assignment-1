namespace Controller.Economy
{
    public interface IEconomyController
    {
        bool HaveFreeGames();
        bool HaveEnoughCoinsForGame();
        void ChargeCoinsForOneGame();
    }
}
