using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PuzzleStartingUI
{
    public class ChosenPictureView : MonoBehaviour
    {
        [Inject] private readonly CoreGameStartingController coreGameStartingController;

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
    }
}
