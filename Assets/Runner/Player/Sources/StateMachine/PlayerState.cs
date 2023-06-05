using FlexEngine.Essence.AppFlow;

namespace Runner.Player.StateMachine
{
    public abstract class PlayerState
    {
        protected readonly PlayerAnimator Animator;
        protected readonly IEnablable Position;
        protected readonly IEnablable Jump;

        public PlayerState(PlayerAnimator animator, IEnablable position, IEnablable jump)
        {
            Animator = animator;
            Position = position;
            Jump = jump;
        }

        public virtual void ApplyStateRules() { }
    }
}

