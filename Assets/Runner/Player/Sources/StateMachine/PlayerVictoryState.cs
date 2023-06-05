using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerVictoryState : PlayerState
    {
        public PlayerVictoryState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetDancing();
            Position.SetEnabled(false);
            Jump.SetEnabled(false);
            Interaction.SetEnabled(false);
            TrapInteraction.SetEnabled(false);
        }
    }
}

