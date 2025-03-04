using Controller.CoreGameStarter.StartingStrategies;
using JetBrains.Annotations;
using UnityEngine;

namespace Controller.CoreGameStarter
{
    [UsedImplicitly]
    public class MockCoreGameStarter : ICoreGameStarter
    {
        public void StartCoreGame(int patternId, int pictureId, IGameStartingStrategy gameStartingStrategy)
        {
            Debug.Log(
                $"[{nameof(MockCoreGameStarter)}] Core game started with pattern == {patternId} and picture == {pictureId} with strategy {gameStartingStrategy.GetType().Name}.");
        }
    }
}