using System;
using Configs;
using Controller.CoreGameStarter;
using Controller.CoreGameStarter.StartingStrategies;
using Controller.DialogsSystem;
using JetBrains.Annotations;
using Model;
using UnityEngine;
using Zenject;

namespace Controller
{
    [UsedImplicitly]
    public class CoreGameInfoController
    {
        public event Action PictureIsChosen;
        public event Action PatternIsChosen;

        [Inject] private readonly CoreGameModel coreGameModel;
        [Inject] private readonly ICoreGameStarter coreGameStarter;
        [Inject] private readonly PicturesConfig picturesConfig;
        [Inject] private readonly DialogSystem dialogSystem;
        [Inject] private readonly IFactory<GamePaymentType, IGameStartingStrategy> gameStartStrategyController;

        public void ChoosePicture(int pictureId)
        {
            coreGameModel.SetPictureId(pictureId);
            PictureIsChosen?.Invoke();
        }

        public void ChoosePattern(int patternId)
        {
            coreGameModel.SetPattern(patternId);
            PatternIsChosen?.Invoke();
        }

        public void StartCoreGame(GamePaymentType gamePaymentType)
        {
            coreGameStarter.StartCoreGame(coreGameModel.PatternId, coreGameModel.PictureId,
                gameStartStrategyController.Create(gamePaymentType));
        }

        public bool GetPictureIsChosen()
        {
            return coreGameModel.PictureId >= 0;
        }

        public bool GetPatternIsChosen()
        {
            return coreGameModel.PatternId >= 0;
        }

        public bool GetPatternIsChosen(int patternId)
        {
            return coreGameModel.PatternId == patternId;
        }

        public Sprite GetPictureSprite()
        {
            return picturesConfig.GetPicture(coreGameModel.PictureId);
        }

        public void ClearPictureSelection()
        {
            coreGameModel.SetPictureId(-1);
            PictureIsChosen?.Invoke();
        }

        public void ClearPatternSelection()
        {
            coreGameModel.SetPattern(-1);
            PatternIsChosen?.Invoke();
        }
    }
}