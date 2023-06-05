using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerDoubleJumpingState : PlayerState
    {
        public PlayerDoubleJumpingState(PlayerAnimator animator, IEnablable position, IEnablable jump) 
            : base(animator, position, jump) { }

        public override void ApplyStateRules()
        {
            Jump.SetEnabled(false);
            Position.SetEnabled(true);
        }
    }
}
