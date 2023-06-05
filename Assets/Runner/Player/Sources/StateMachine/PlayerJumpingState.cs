using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerJumpingState : PlayerState
    {
        public PlayerJumpingState(PlayerAnimator animator, IEnablable position, IEnablable jump) 
            : base(animator, position, jump) { }

        public override void ApplyStateRules()
        {
            Animator.SetJumping();
            Jump.SetEnabled(true);
            Position.SetEnabled(true);
        }
    }
}

