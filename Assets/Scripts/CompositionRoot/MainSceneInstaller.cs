using Configs;
using CoreGameStarter;
using PictureChoosingUI;
using UnityEngine;
using Zenject;

namespace CompositionRoot
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private PicturesConfig picturesConfig;
        [SerializeField] private PictureView pictureViewPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInstance(picturesConfig);
            Container.BindInstance(pictureViewPrefab);
            
            Container.Bind<IFactory<int, Transform, PictureView>>().To<PictureViewsFactory>().AsSingle();
            
            Container.Bind<CoreGameModel>().AsSingle();
            Container.Bind<CoreGameStartingController>().AsSingle();
            Container.Bind<ICoreGameStarter>().To<MockCoreGameStarter>().AsSingle();
        }
    }
}
