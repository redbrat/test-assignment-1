using UnityEngine;
using Zenject;

namespace PuzzleStartingUI
{
    public class PuzzleStartingView : MonoBehaviour
    {
        [Inject] private readonly CoreGameStartingController coreGameStartingController;

        [SerializeField] private GameObject visuals;

        [Inject]
        private void Init()
        {
            coreGameStartingController.PictureIsChosen += OnPictureIsChosen;
            UpdateVisuals();
        }

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
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            var pictureIsChosen = coreGameStartingController.GetPictureIsChosen(); 
            visuals.SetActive(pictureIsChosen);
        }

        private void OnPictureIsChosen()
        {
            UpdateVisuals();
        }

        private void OnDestroy()
        {
            if (coreGameStartingController != null)
            {
                coreGameStartingController.PictureIsChosen -= OnPictureIsChosen;
            }
        }
    }
}
