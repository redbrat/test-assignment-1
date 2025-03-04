using Controller;
using Controller.CoreGameStarter;
using Controller.DialogsSystem;
using UnityEngine;
using Zenject;

namespace View.PuzzleStarting
{
    public class PuzzleStartingView : MonoBehaviour, IDialog
    {
        [Inject] private readonly CoreGameInfoController coreGameStartingController;

        [SerializeField] private GameObject visuals;

        public void OnPatternClick(int patternId)
        {
            if (coreGameStartingController.GetPatternIsChosen(patternId))
            {
                coreGameStartingController.ClearPatternSelection();
            }
            else
            {
                coreGameStartingController.ChoosePattern(patternId);
            }
        }

        public void OnFreeStartClick()
        {
            coreGameStartingController.StartCoreGame(GamePaymentType.Free);
        }

        public void OnCoinsStartClick()
        {
            coreGameStartingController.StartCoreGame(GamePaymentType.Coins);
        }

        public void OnAdsStartClick()
        {
            coreGameStartingController.StartCoreGame(GamePaymentType.Ads);
        }

        public void OnShadowClick()
        {
            coreGameStartingController.ClearPictureSelection();
        }

        void IDialog.Show()
        {
            visuals.SetActive(true);
        }

        void IDialog.Hide()
        {
            visuals.SetActive(false);
        }
    }
}
