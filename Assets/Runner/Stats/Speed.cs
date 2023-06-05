using System.Threading.Tasks;
using FlexEngine.Essence.AppFlow;
using Runner.GameFlow;
using Runner.Shared;

namespace Runner.Player
{
    public class Speed : IRestartListener, IReadOnlySpeed, IContinueListener
    {
        public float CurrentValue { get; private set; }
        private readonly float _basicValue;
        private readonly float _boostedValue;
        private readonly float _boostTime;
        private readonly float _continueSlowValue;
        private readonly float _continueSlowDuration;
        public Timer BoostTimer { get; }
        public Timer SlowTimer { get; }

        private bool _canBoostSpeed = true;

        public Speed(float basicValue, float boostedValue, float boostTime, float continueSlowValue, float continueSlowDuration)
        {
            _basicValue = basicValue;
            _boostedValue = boostedValue;
            _boostTime = boostTime;
            _continueSlowValue = continueSlowValue;
            _continueSlowDuration = continueSlowDuration;
            BoostTimer = new Timer();
            SlowTimer = new Timer();
            
            BoostTimer.TimeIsOver += OnBoostTimeEnded;
            SlowTimer.TimeIsOver += OnSlowTimeIsOver;
        }

        public void OnRestart()
        {
            _canBoostSpeed = true;
            BoostTimer.StopTimer();
            CurrentValue = _basicValue;
        }

        public void BoostSpeed()
        {
            if (!_canBoostSpeed)
                return;
            
            CurrentValue = _boostedValue;
            BoostTimer.AddTime(_boostTime);
        }

        private void OnBoostTimeEnded()
        {
            CurrentValue = _basicValue;
        }

        public void OnContinue()
        {
            _canBoostSpeed = false;
            CurrentValue = _continueSlowValue;
            SlowTimer.AddTime(_continueSlowDuration);
        }
        
        private void OnSlowTimeIsOver()
        {
            CurrentValue = _basicValue;
            _canBoostSpeed = true;
        }
    }

    public interface IReadOnlySpeed
    {
        float CurrentValue { get; }
    }
}

