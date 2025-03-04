using UnityEngine;
using Zenject;

namespace PuzzleStartingUI
{
    public class PatternChoosingButtonView : MonoBehaviour
    {
        [Inject] private readonly CoreGameStartingController coreGameStartingController;
        
        [SerializeField] private int patternId;
        [SerializeField] private GameObject selectionFrame;
        [SerializeField] private PuzzleStartingView puzzleStartingView;

        [Inject]
        private void Init()
        {
            coreGameStartingController.PatternIsChosen += OnPatternIsChosen;
            OnPatternIsChosen();
        }

        private void OnPatternIsChosen()
        {
            var ourPatternIsChosen = coreGameStartingController.GetPatternIsChosen(patternId);
            selectionFrame.SetActive(ourPatternIsChosen);;
        }

        public void OnClick()
        {
            puzzleStartingView.OnPatternClick(patternId);
        }
    }
}
