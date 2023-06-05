using UnityEngine;

namespace FlexEngine.Essence.Animations.Internal
{
    internal class AnimatorWaitStateSource : AnimatorSource
    {
        private readonly Animator _animator;
        private readonly int _layer;
        private readonly int _stateNameHash;

        public AnimatorWaitStateSource(Animator animator, int stateHash, int layer)
        {
            _animator = animator;
            _stateNameHash = stateHash;
            _layer = layer;
        }

        public override bool IsComplete()
        {
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            return state.fullPathHash == _stateNameHash || state.shortNameHash == _stateNameHash;
        }
    }
}

