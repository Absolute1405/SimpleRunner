using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public abstract class PlayerState
    {
        public int Grade { get; }
        protected readonly PlayerAnimator Animator;
        protected readonly IEnablable Position;
        protected readonly IEnablable Jump;
        protected readonly IEnablable Interaction;
        protected readonly IEnablable TrapInteraction;

        public PlayerState(PlayerAnimator animator, IEnablable position, IEnablable jump, IEnablable interaction, IEnablable trapInteraction, int grade)
        {
            Animator = animator;
            Position = position;
            Jump = jump;
            Interaction = interaction;
            TrapInteraction = trapInteraction;
            Grade = grade;
        }

        public virtual void ApplyStateRules() { }
    }
}

