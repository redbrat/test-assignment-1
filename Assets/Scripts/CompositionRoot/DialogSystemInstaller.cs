using Controller;
using Controller.DialogsSystem;
using UnityEngine;
using View.PuzzleStarting;
using Zenject;

namespace CompositionRoot
{
    public class DialogSystemInstaller : MonoInstaller
    {
        [SerializeField] private PuzzleStartingView puzzleStartingView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(new DialogSystem(puzzleStartingView));
            Container.BindInterfacesAndSelfTo<DialogsController>().AsSingle().NonLazy();
        }
    }
}
