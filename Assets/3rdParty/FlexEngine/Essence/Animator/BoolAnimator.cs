using FlexEngine.Essence.Animations.Internal;
using System.Threading.Tasks;
using UnityEngine;

namespace FlexEngine.Essence.Animations
{
    [RequireComponent(typeof(Animator))]
    public class BoolAnimator : MonoBehaviour
    {
        [SerializeField] private string _boolParameter = "Visible";
        [SerializeField] private string _trueState = "Visible";
        [SerializeField] private string _falseState = "Hidden";

        private Animator animator => GetComponent<Animator>();
        public bool boolValue => animator.GetBool(_boolParameter);

        public void SetValue(bool value)
        {
            animator.SetBool(_boolParameter, value);
        }

        public async Task SetValueAsync(bool value)
        {
            animator.SetBool(_boolParameter, value);
            if (value)
            {
                await animator.WaitStateAsync(_trueState);
            }
            else
            {
                await animator.WaitStateAsync(_falseState);
            }
        }

        public void SetValueImmediately(bool value)
        {
            animator.SetBool(_boolParameter, value);
            if (value)
            {
                animator.Play(_trueState);
            }
            else
            {
                animator.Play(_falseState);
            }
        }
    }
}

