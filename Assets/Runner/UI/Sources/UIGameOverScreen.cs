using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class UIGameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button _adButton;
        [SerializeField] private Button _restartButton;

        public event Action AdShown;
        public event Action RestartClicked;
        
        private void OnEnable()
        {
            _adButton.onClick.AddListener(OnAdButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _adButton.onClick.RemoveListener(OnAdButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            RestartClicked?.Invoke();
        }

        private void OnAdButtonClicked()
        {
            AdShown?.Invoke();
        }
    }
}

