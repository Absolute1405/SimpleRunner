using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerGameOverState : PlayerState
    {
        public PlayerGameOverState(PlayerAnimator animator, IEnablable position, IEnablable jump) 
            : base(animator, position, jump)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetGameOver();
            Position.SetEnabled(false);
            Jump.SetEnabled(false);
        }
    }
}

