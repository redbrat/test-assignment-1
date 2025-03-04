using System;
using Controller.DialogsSystem;
using JetBrains.Annotations;
using View.PuzzleStarting;
using Zenject;

namespace Controller
{
    [UsedImplicitly]
    public class DialogsController : IDisposable
    {
        [Inject] private readonly DialogSystem dialogSystem;
        [Inject] private readonly CoreGameInfoController coreGameStartingController;
    
        [Inject]
        private void Init()
        {
            coreGameStartingController.PictureIsChosen += UpdateVisuals;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            var pictureIsChosen = coreGameStartingController.GetPictureIsChosen();
            if (pictureIsChosen)
            {
                dialogSystem.ShowDialog<PuzzleStartingView>();
            }
            else
            {
                dialogSystem.Hide();
            }
        }

        public void Dispose()
        {
            coreGameStartingController.PictureIsChosen -= UpdateVisuals;
        }
    }
}
