using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerDoubleJumpingState : PlayerState
    {
        public PlayerDoubleJumpingState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade) { }

        public override void ApplyStateRules()
        {
            Jump.SetEnabled(false);
            Position.SetEnabled(true);
            Interaction.SetEnabled(true);
            TrapInteraction.SetEnabled(true);
        }
    }
}