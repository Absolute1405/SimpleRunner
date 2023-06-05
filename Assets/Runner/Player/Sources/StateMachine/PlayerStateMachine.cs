using System.Collections.Generic;
using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerStateMachine
    {
        private readonly SortedDictionary<int, PlayerState> _currentStates = new SortedDictionary<int, PlayerState>();

        private readonly PlayerState _movingState;
        private readonly PlayerState _jumpingState;
        private readonly PlayerState _doubleJumpingState;
        private readonly PlayerState _rotatingState;
        
        private readonly PlayerState _victoryState;
        private readonly PlayerState _gameOverState;

        private readonly PlayerState _invulnerableState;
        private readonly PlayerState _vulnerableState;
        
        public PlayerStateMachine(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction)
        {
            _movingState = new PlayerMovingState(animator, position, jump, interaction, trapInteraction, 0);
            _jumpingState = new PlayerJumpingState(animator, position, jump, interaction, trapInteraction, 0);
            _doubleJumpingState = new PlayerDoubleJumpingState(animator, position, jump, interaction, trapInteraction, 0);
            _rotatingState = new PlayerRotatingState(animator, position, jump, interaction, trapInteraction, 0);
            
            _invulnerableState = new PlayerInvulnerableSubState(animator, position, jump, interaction, trapInteraction, 1);
            _vulnerableState = new PlayerVulnerableSubState(animator, position, jump, interaction, trapInteraction, 1);
            
            _victoryState = new PlayerVictoryState(animator, position, jump, interaction, trapInteraction, 2);
            _gameOverState = new PlayerGameOverState(animator, position, jump, interaction, trapInteraction, 2);
        }

        public void SetMoving() => SetState(0, _movingState);

        public void SetJumping() => SetState(0, _jumpingState);

        public void SetDoubleJumping() => SetState(0, _doubleJumpingState);

        public void SetRotating() => SetState(0, _rotatingState);

        public void SetVictory() => SetState(2, _victoryState);
        public void SetGameOver() => SetState(2, _gameOverState);

        public void SetInGame() => SetState(2, null);

        public void SetInvulnerable() => SetState(1, _invulnerableState);
        public void SetVulnerable() => SetState(1, _vulnerableState);


        public void OnGrounded()
        {
            if (!_currentStates.ContainsKey(0))
                return;
            
            if (_currentStates[0] == _jumpingState || _currentStates[0] == _doubleJumpingState)
                SetState(0, _movingState);
        }

        private void SetState(int grade, PlayerState nextState)
        {
            if (!_currentStates.ContainsKey(grade))
                _currentStates.Add(grade, nextState);

            _currentStates[grade] = nextState;
            
            foreach (var stateGrade in _currentStates.Keys)
            {
                _currentStates[stateGrade]?.ApplyStateRules();
            }
        }
    }
}

