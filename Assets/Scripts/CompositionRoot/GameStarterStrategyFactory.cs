using System;
using Controller.CoreGameStarter;
using Controller.CoreGameStarter.StartingStrategies;
using JetBrains.Annotations;
using Zenject;

namespace CompositionRoot
{
    [UsedImplicitly]
    public class GameStarterStrategyFactory : IFactory<GamePaymentType, IGameStartingStrategy>
    {
        [Inject] private readonly DiContainer diContainer;
        
        public IGameStartingStrategy Create(GamePaymentType gamePaymentType)
        {
            var strategyType = GetStrategyType(gamePaymentType);
            var instance = diContainer.Instantiate(strategyType);
            return (IGameStartingStrategy)instance;
        }

        private Type GetStrategyType(GamePaymentType gamePaymentType)
        {
            switch (gamePaymentType)
            {
                case GamePaymentType.Ads:
                    return typeof(AdsStartStrategy);
                case GamePaymentType.Coins:
                    return typeof(CoinsStartStrategy);
            }
            return typeof(FreeStartStrategy);
        }
    }
}
