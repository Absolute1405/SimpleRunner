using System;
using Runner.GameFlow;
using Runner.Level;
using Runner.Shared;
using Runner.Stats;
using UnityEngine;

namespace Runner.UI
{
    public class UIFacade : MonoBehaviour, IRestartListener, IGameOverListener, IContinueListener, IRestartInvoker, IContinueInvoker, IVictoryListener
    {
        [SerializeField] private UIHealthView _healthView;
        [SerializeField] private UISwitcher _switcher;
        [SerializeField] private UIStatistics _statistics;
        [SerializeField] private UIGameOverScreen _gameOverScreen;
        [SerializeField] private UIVictoryScreen _victoryScreen;
        
        public event Action Restart;
        public event Action Continue;
        public event Action LevelCompleted;

        private void OnEnable()
        {
            _gameOverScreen.AdShown += InvokeContinue;
            _gameOverScreen.RestartClicked += InvokeRestart;
            _victoryScreen.NextLevelClicked += InvokeLevelCompleted;
        }

        private void OnDisable()
        {
            _gameOverScreen.AdShown -= InvokeContinue;
            _gameOverScreen.RestartClicked -= InvokeRestart;
            _victoryScreen.NextLevelClicked -= InvokeLevelCompleted;
        }

        public void Initialize(LevelLineChunkModel[] chunkModels, IHealth health, IReadOnlyPlayerStatistics statistics)
        {
            _healthView.Initialize(health);
            _statistics.Initialize(statistics, chunkModels);
        }

        public async void OnRestart()
        {
            _statistics.SetVisible(false);
            _healthView.OnRestart();
            await _switcher.SetScreen(UIScreenName.InGame);
        }

        public async void OnGameOver()
        {
            await _switcher.SetScreen(UIScreenName.GameOver);
            _statistics.Refresh();
            _statistics.SetVisible(true);
        }

        public async void OnContinue()
        {
            _statistics.SetVisible(false);
            await _switcher.SetScreen(UIScreenName.InGame);
        }

        public async void OnVictory()
        {
            await _switcher.SetScreen(UIScreenName.Victory);
            _statistics.Refresh();
            _statistics.SetVisible(true);
        }

        public void InvokeContinue() => Continue?.Invoke();
        public void InvokeRestart() => Restart?.Invoke();
        public void InvokeLevelCompleted() => LevelCompleted?.Invoke();
    }
}

