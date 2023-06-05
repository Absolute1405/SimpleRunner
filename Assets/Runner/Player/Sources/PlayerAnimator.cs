using FlexEngine.Essence.Animations;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private BoolAnimator _invulAnimator;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _stateParamName = "State";
        [SerializeField] private string _danceTriggerName = "Dance";
        [SerializeField] private string _gameOverTriggerName = "GameOver";
        [SerializeField] private int _unreachableStateIndex = -1;


        public void SetJumping()
        {
            _animator.SetInteger(_stateParamName, 1);
        }

        public void SetRunning()
        {
            _animator.SetInteger(_stateParamName, 0);
        }

        public void SetDancing()
        {
            _animator.SetInteger(_stateParamName, _unreachableStateIndex);
            _animator.SetTrigger(_danceTriggerName);
        }

        public void SetInvulnerable(bool value)
        {
            _invulAnimator.SetValue(value);
        }

        public void SetGameOver()
        {
            _animator.SetInteger(_stateParamName, _unreachableStateIndex);
            _animator.SetTrigger(_gameOverTriggerName);
        }
    }
}

