using UnityEngine;
using UnityEngine.UI;
using GameBase;

namespace UI
{
    public class NameInputUI : MonoBehaviour
    {
        [SerializeField] private ScoreBoardData _scoreBoardData;
        [SerializeField] private InputField _inputField;
        [SerializeField] private Button _inputButton;

        private void Awake()
        {
            _inputButton.onClick.AddListener(UpdateScoreBoard);
        }

        public void UpdateScoreBoard()
        {
            _scoreBoardData.AddNewRecord(_inputField.text, PointCounter.CurrentPoints);
        }
    }
}