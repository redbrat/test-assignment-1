using JetBrains.Annotations;
using UnityEngine;

namespace CoreGameStarter
{
    [UsedImplicitly]
    public class MockCoreGameStarter : ICoreGameStarter
    {
        public void StartCoreGame(int patternId, int pictureId)
        {
            Debug.Log(
                $"[{nameof(MockCoreGameStarter)}] Core game started with pattern == {patternId} and picture == {pictureId}.");
        }
    }
}