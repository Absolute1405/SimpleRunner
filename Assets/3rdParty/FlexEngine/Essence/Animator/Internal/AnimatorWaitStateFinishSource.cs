using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlexEngine.Essence.Animations.Internal
{
    internal class AnimatorWaitStateFinishSource : AnimatorSource
    {
        private readonly UnityEngine.Animator _animator;
        private readonly int _layer;
        private readonly int _waitingStateHash;

        private bool _isWaitStateStart = true;

        public AnimatorWaitStateFinishSource(UnityEngine.Animator animator, int stateHash, int layer)
        {
            _animator = animator;
            _waitingStateHash = stateHash;
            _layer = layer;
        }

        public override bool IsComplete()
        {
            var state = _animator.GetCurrentAnimatorStateInfo(_layer);
            UpdateStateStart(state);

            // wait switch to wait state
            if (_isWaitStateStart)
            {
                return false;
            }

            // wait finish state
            return !IsStateEqual(state);
        }

        private void UpdateStateStart(AnimatorStateInfo stateInfo)
        {
            var value = IsStateEqual(stateInfo);
            if (value)
            {
                _isWaitStateStart = false;
            }
        }

        private bool IsStateEqual(AnimatorStateInfo stateInfo)
        {
            return stateInfo.fullPathHash == _waitingStateHash || stateInfo.shortNameHash == _waitingStateHash;
        }
    }
}

