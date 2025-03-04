using Configs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PictureChoosingUI
{
    public class PictureView : MonoBehaviour
    {
        [Inject] private readonly CoreGameStartingController coreGameStartingController;
        [Inject] private readonly PicturesConfig picturesConfig;

        [SerializeField] private Image image;
        
        private int pictureId;
    
        public void Init(int pictureId)
        {
            this.pictureId = pictureId;

            image.sprite = picturesConfig.GetPicture(pictureId);
        }
    
        public void OnClick()
        {
            coreGameStartingController.ChoosePicture(pictureId);
        }
    }
}
