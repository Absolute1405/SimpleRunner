using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerVulnerableSubState : PlayerState
    {
        public PlayerVulnerableSubState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetInvulnerable(false);
            Interaction.SetEnabled(true);
            TrapInteraction.SetEnabled(true);
        }
    }
}

