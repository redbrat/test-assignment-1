using Configs;
using Controller;
using Controller.CoreGameStarter;
using Model;
using UnityEngine;
using View.PictureChoosingUI;
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
            Container.Bind<CoreGameInfoController>().AsSingle();
            Container.Bind<ICoreGameStarter>().To<MockCoreGameStarter>().AsSingle();
        }
    }
}
