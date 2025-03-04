using Controller;
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

        public void OnStartClick()
        {
            coreGameStartingController.StartCoreGame();
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
