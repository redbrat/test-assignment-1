using Controller.CoreGameStarter.StartingStrategies;

namespace Controller.CoreGameStarter
{
    public interface ICoreGameStarter
    {
        void StartCoreGame(int patternId, int pictureId, IGameStartingStrategy gameStartingStrategy);
    }
}
