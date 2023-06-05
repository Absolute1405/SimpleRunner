using System;
using Runner.GameFlow;

namespace Runner.Stats
{
    public class Health : IRestartListener, IContinueListener, IGameOverInvoker, IHealth
    {
        public int CurrentValue { get; private set; }
        
        public event Action GameOver;
        public event Action Decreased; 
        public event Action Increased;

        private readonly int _startValue;
        private readonly int _continueValue;
        private readonly int _boosterValue;

        public Health(int startValue, int continueValue, int boosterValue)
        {
            _startValue = startValue;
            _continueValue = continueValue;
            _boosterValue = boosterValue;
        }

        public void OnRestart()
        {
            CurrentValue = _startValue;
        }

        public void OnContinue()
        {
            CurrentValue = _continueValue;
            Increased?.Invoke();
        }

        public void DecreaseByTrap()
        {
            CurrentValue--;
            Decreased?.Invoke();
            
            if (CurrentValue <= 0)
                GameOver?.Invoke();
        }

        public void IncreaseByBooster()
        {
            var newValue = CurrentValue + _boosterValue;

            if (newValue >= _startValue)
            {
                CurrentValue = _startValue;
            }
            else
            {
                CurrentValue = newValue;
                Increased?.Invoke();
            }
        }

    }

    public interface IHealth
    {
        int CurrentValue { get;}
        event Action Decreased; 
        event Action Increased;
    }
}

