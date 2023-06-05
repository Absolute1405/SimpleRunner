namespace Runner.GameFlow
{
    public class GameEventsOperator
    {
        private IRestartInvoker[] _restartInvokers;
        private IGameOverInvoker[] _gameOverInvokers;
        private IContinueInvoker[] _continueInvokers;
        private IVictoryInvoker[] _victoryInvokers;
        
        private IRestartListener[] _restartListeners;
        private IGameOverListener[] _gameOverListeners;
        private IContinueListener[] _continueListeners;
        private IVictoryListener[] _victoryListeners;

        public void FillGameOverInvokersInOrder(params IGameOverInvoker[] gameOverInvokers)
        {
            _gameOverInvokers = gameOverInvokers;

            foreach (var invoker in _gameOverInvokers)
            {
                invoker.GameOver += OnGameOver;
            }
        }

        private void OnGameOver()
        {
            foreach (var listener in _gameOverListeners)
            {
                listener.OnGameOver();
            }
        }
        
        public void FillVictoryInvokersInOrder(params IVictoryInvoker[] victoryInvokers)
        {
            _victoryInvokers = victoryInvokers;

            foreach (var invoker in _victoryInvokers)
            {
                invoker.Victory += OnVictory;
            }
        }

        private void OnVictory()
        {
            foreach (var listener in _victoryListeners)
            {
                listener.OnVictory();
            }
        }

        public void FillContinueInvokersInOrder(params IContinueInvoker[] continueInvokers)
        {
            _continueInvokers = continueInvokers;
            
            foreach (var invoker in _continueInvokers)
            {
                invoker.Continue += OnContinue;
            }
        }

        private void OnContinue()
        {
            foreach (var listener in _continueListeners)
            {
                listener.OnContinue();
            }
        }

        public void FillRestartInvokersInOrder(params IRestartInvoker[] restartInvokers)
        {
            _restartInvokers = restartInvokers;
            
            foreach (var invoker in _restartInvokers)
            {
                invoker.Restart += OnRestart;
            }
        }

        private void OnRestart()
        {
            foreach (var listener in _restartListeners)
            {
                listener.OnRestart();
            }
        }

        public void FillGameOverListenersInOrder(params IGameOverListener[] gameOverListeners) => _gameOverListeners = gameOverListeners;
        public void FillContinueListenersInOrder(params IContinueListener[] continueListeners) => _continueListeners = continueListeners;
        public void FillRestartListenersInOrder(params IRestartListener[] restartListeners) => _restartListeners = restartListeners;
        public void FillVictoryListenersInOrder(params IVictoryListener[] victoryListeners) => _victoryListeners = victoryListeners;


        public void StartGame()
        {
            OnRestart();
        }
        
        public void Clear()
        {
            foreach (var invoker in _continueInvokers)
            {
                invoker.Continue -= OnContinue;
            }
            
            foreach (var invoker in _restartInvokers)
            {
                invoker.Restart -= OnRestart;
            }
            
            foreach (var invoker in _gameOverInvokers)
            {
                invoker.GameOver -= OnGameOver;
            }
        }
    }
}
