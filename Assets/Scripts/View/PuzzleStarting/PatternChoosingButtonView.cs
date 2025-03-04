using Controller;
using UnityEngine;
using Zenject;

namespace View.PuzzleStarting
{
    public class PatternChoosingButtonView : MonoBehaviour
    {
        [Inject] private readonly CoreGameInfoController coreGameStartingController;
        
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

        private void OnDestroy()
        {
            if (coreGameStartingController != null)
            {
                coreGameStartingController.PatternIsChosen -= OnPatternIsChosen;
            }
        }
    }
}
