using JetBrains.Annotations;
using PictureChoosingUI;
using UnityEngine;
using Zenject;

namespace CompositionRoot
{
    [UsedImplicitly]
    public class PictureViewsFactory : IFactory<int, Transform, PictureView>
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly PictureView pictureViewPrefab;
        
        public PictureView Create(int pictureId, Transform root)
        {
            var instance = diContainer.InstantiatePrefabForComponent<PictureView>(pictureViewPrefab, root);
            instance.Init(pictureId);
            return instance;
        }
    }
}
