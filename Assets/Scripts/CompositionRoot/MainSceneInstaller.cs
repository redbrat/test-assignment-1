using Configs;
using Controller;
using Controller.AdsSystem;
using Controller.CoreGameStarter;
using Controller.CoreGameStarter.StartingStrategies;
using Controller.Economy;
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
            Container.Bind<IFactory<GamePaymentType, IGameStartingStrategy>>().To<GameStarterStrategyFactory>()
                .AsSingle();
            
            Container.Bind<CoreGameModel>().AsSingle();
            Container.Bind<CoreGameInfoController>().AsSingle();
            Container.Bind<ICoreGameStarter>().To<MockCoreGameStarter>().AsSingle();
            Container.Bind<IEconomyController>().To<MockEconomyController>().AsSingle();
            Container.Bind<IAdsSystem>().To<MockAdsSystem>().AsSingle();
        }
    }
}
