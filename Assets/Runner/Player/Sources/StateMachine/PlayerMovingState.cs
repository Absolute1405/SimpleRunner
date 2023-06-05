using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerMovingState : PlayerState
    {
        public PlayerMovingState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade) { }

        public override void ApplyStateRules()
        {
            Animator.SetRunning();
            Jump.SetEnabled(true);
            Position.SetEnabled(true);
            Interaction.SetEnabled(true);
        }
    }
}
