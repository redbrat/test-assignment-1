using Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View.PuzzleStarting
{
    public class ChosenPictureView : MonoBehaviour
    {
        [Inject] private readonly CoreGameInfoController coreGameStartingController;

        [SerializeField] private Image pictureImage;
        
        [Inject]
        private void Init()
        {
            coreGameStartingController.PictureIsChosen += OnPictureIsChosen;
            OnPictureIsChosen();
        }

        private void OnPictureIsChosen()
        {
            if (coreGameStartingController.GetPictureIsChosen())
            {
                pictureImage.sprite = coreGameStartingController.GetPictureSprite();
            }
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
