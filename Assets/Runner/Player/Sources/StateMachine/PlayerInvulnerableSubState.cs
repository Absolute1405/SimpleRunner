using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public class PlayerInvulnerableSubState : PlayerState
    {
        public PlayerInvulnerableSubState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade) 
            : base(animator, position, jump, interaction, trapInteraction, grade)
        {
        }

        public override void ApplyStateRules()
        {
            Animator.SetInvulnerable(true);
            Interaction.SetEnabled(true);
            TrapInteraction.SetEnabled(false);
            
        }
    }
}

