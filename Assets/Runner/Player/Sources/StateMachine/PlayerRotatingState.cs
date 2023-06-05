using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerRotatingState : PlayerState
    {
        public PlayerRotatingState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade) { }

        public override void ApplyStateRules()
        {
            Jump.SetEnabled(false);
            Position.SetEnabled(false);
            Interaction.SetEnabled(true);
            TrapInteraction.SetEnabled(false);
        }
    }
}
