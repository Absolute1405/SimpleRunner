using UnityEngine;

namespace FlexEngine.Essence.Animations.Internal
{
    internal class AnimatorWaitStateEnterSource : AnimatorSource
    {
        private readonly UnityEngine.Animator _animator;
        private readonly int _layer;
        private readonly int _waitingStateHash;
        private AnimatorStateInfo _stateInfo;

        public AnimatorWaitStateEnterSource(UnityEngine.Animator animator, int stateHash, int layer)
        {
            _animator = animator;
            _waitingStateHash = stateHash;
            _layer = layer;
            _stateInfo = _animator.GetCurrentAnimatorStateInfo(_layer);
        }

        public override bool IsComplete()
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(_layer);
            if (AreStateEquals(stateInfo, _stateInfo)) return false;
            _stateInfo = stateInfo;
            return IsStateEqual(stateInfo);
        }

        private bool AreStateEquals(AnimatorStateInfo stateInfo1, AnimatorStateInfo stateInfo2)
        {
            return stateInfo1.fullPathHash == stateInfo2.fullPathHash || stateInfo1.shortNameHash == stateInfo2.shortNameHash;
        }

        private bool IsStateEqual(AnimatorStateInfo stateInfo)
        {
            return stateInfo.fullPathHash == _waitingStateHash || stateInfo.shortNameHash == _waitingStateHash;
        }
    }
}

