using Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View.PuzzleStarting
{
    public class StartPuzzleButtonView : MonoBehaviour
    {
        [Inject] private readonly CoreGameInfoController coreGameStartingController;
        
        [SerializeField] private Button[] startButtons;
        
        [Inject]
        private void Init()
        {
            coreGameStartingController.PatternIsChosen += OnPatternIsChosen;
            OnPatternIsChosen();
        }

        private void OnPatternIsChosen()
        {
            var patternIsChosen = coreGameStartingController.GetPatternIsChosen();
            foreach (var startButton in startButtons)
            {
                startButton.interactable = patternIsChosen;
            }
        }

        private void OnDestroy()
        {
            if (coreGameStartingController != null)
            {
                coreGameStartingController.PatternIsChosen -= OnPatternIsChosen;
            }
        }
    }
}
