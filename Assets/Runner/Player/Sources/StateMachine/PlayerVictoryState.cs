using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerVictoryState : PlayerState
    {
        public PlayerVictoryState(PlayerAnimator animator, IEnablable position, IEnablable jump) 
            : base(animator, position, jump)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetDancing();
            Position.SetEnabled(false);
            Jump.SetEnabled(false);
        }
    }
}

