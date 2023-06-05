using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerMovingState : PlayerState
    {
        public PlayerMovingState(PlayerAnimator animator, IEnablable position, IEnablable jump) 
            : base(animator, position, jump) { }

        public override void ApplyStateRules()
        {
            Animator.SetRunning();
            Jump.SetEnabled(true);
            Position.SetEnabled(true);
        }
    }
}
