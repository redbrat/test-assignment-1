using Configs;
using UnityEngine;
using Zenject;

namespace View.PictureChoosingUI
{
    public class PictureChoosingView : MonoBehaviour
    {
        [Inject] private readonly IFactory<int, Transform, PictureView> pictureViewFactory;
        [Inject] private readonly PicturesConfig picturesConfig;
        
        [SerializeField] private Transform picturesRoot;

        [Inject]
        private void Init()
        {
            for (var i = 0; i < picturesConfig.PicturesCount; i++)
            {
                pictureViewFactory.Create(i, picturesRoot);
            }
        }
    }
}
