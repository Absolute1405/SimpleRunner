using Runner.GameFlow;
using Runner.Player;
using Runner.Shared;

namespace Runner.Stats
{
    public class Invulnerable : IRestartListener, IContinueListener, IGameOverListener
    {
        public Timer Timer { get; } 
        private readonly float _invulnerableDuration;
        private readonly IPlayerInvulnerable _player;

        public Invulnerable(float invulnerableDuration, IPlayerInvulnerable player, IPlayerInvulnerableTrigger trigger)
        {
            Timer = new Timer();
            _invulnerableDuration = invulnerableDuration;
            _player = player;
            Timer.TimeIsOver += OnTimeIsOver;
            trigger.InvulBoosterTriggered += StartInvulnerable;
        }

        private void OnTimeIsOver()
        {
            _player.SetInvulnerable(false);
        }
        
        public void OnRestart()
        {
            _player.SetInvulnerable(false);
            Timer.StopTimer();
        }

        public void OnContinue()
        {
            _player.SetInvulnerable(false);
            Timer.StopTimer();
        }

        public void OnGameOver()
        {
            _player.SetInvulnerable(false);
            Timer.StopTimer();
        }

        public void StartInvulnerable()
        {
            _player.SetInvulnerable(true);
            Timer.AddTime(_invulnerableDuration);
        }
    }
}

