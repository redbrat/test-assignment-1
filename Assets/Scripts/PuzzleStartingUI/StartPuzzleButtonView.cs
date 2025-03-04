using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PuzzleStartingUI
{
    public class StartPuzzleButtonView : MonoBehaviour
    {
        [Inject] private readonly CoreGameStartingController coreGameStartingController;
        
        [SerializeField] private Button button;
        
        [Inject]
        private void Init()
        {
            coreGameStartingController.PatternIsChosen += OnPatternIsChosen;
            OnPatternIsChosen();
        }

        private void OnPatternIsChosen()
        {
            var patternIsChosen = coreGameStartingController.GetPatternIsChosen();
            button.interactable = patternIsChosen;
        }
    }
}
