using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class UIVictoryScreen : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;

        public event Action NextLevelClicked;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClicked);
        }

        private void OnNextLevelButtonClicked()
        {
            NextLevelClicked?.Invoke();
        }
    }
}

