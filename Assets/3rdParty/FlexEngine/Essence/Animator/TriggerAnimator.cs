using FlexEngine.Essence.Animations.Internal;
using System.Threading.Tasks;
using UnityEngine;

namespace FlexEngine.Essence.Animations
{
    [RequireComponent(typeof(Animator))]
    public class TriggerAnimator : MonoBehaviour
    {
        [SerializeField] private string _trigger = "Run";
        [SerializeField] private string _stateName = "Run";

        public void Run()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(_trigger);
        }

        public async Task RunAsync()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(_trigger);
            await animator.WaitStateFinishAsync(_stateName);
        }
    }
}

