using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerStateMachine
    {
        private PlayerState _currentState;

        private readonly PlayerState _movingState;
        private readonly PlayerState _jumpingState;
        private readonly PlayerState _doubleJumpingState;

        private readonly PlayerState _victoryState;
        private readonly PlayerState _gameOverState;

        public PlayerStateMachine(PlayerAnimator animator, IEnablable position, IEnablable jump)
        {
            _movingState = new PlayerMovingState(animator, position, jump);
            _jumpingState = new PlayerJumpingState(animator, position, jump);
            _doubleJumpingState = new PlayerDoubleJumpingState(animator, position, jump);
            _victoryState = new PlayerVictoryState(animator, position, jump);
            _gameOverState = new PlayerGameOverState(animator, position, jump);
        }

        public void SetMoving() => SetState(_movingState);

        public void SetJumping() => SetState(_jumpingState);

        public void SetDoubleJumping() => SetState(_doubleJumpingState);

        public void SetVictory() => SetState(_victoryState);
        public void SetGameOver() => SetState(_gameOverState);

        public void OnGrounded()
        {
            if (_currentState == _jumpingState || _currentState == _doubleJumpingState)
                SetState(_movingState);
        }

        private void SetState(PlayerState nextState)
        {
            _currentState = nextState;
            _currentState.ApplyStateRules();
        }
    }
}

