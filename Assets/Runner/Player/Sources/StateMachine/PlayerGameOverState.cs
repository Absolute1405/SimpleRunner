using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerGameOverState : PlayerState
    {
        public PlayerGameOverState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetGameOver();
            Position.SetEnabled(false);
            Jump.SetEnabled(false);
            Interaction.SetEnabled(false);
        }
    }
}

