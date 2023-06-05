using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerJumpingState : PlayerState
    {
        public PlayerJumpingState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade) { }

        public override void ApplyStateRules()
        {
            Animator.SetJumping();
            Jump.SetEnabled(true);
            Position.SetEnabled(true);
            Interaction.SetEnabled(true);
            TrapInteraction.SetEnabled(true);
        }
    }
}

