using FlexEngine.Essence.UnityExtensions;
using System.Threading.Tasks;
using UnityEngine;

namespace FlexEngine.Essence.Animations.Internal
{
    internal static class AnimatorExtension
    {
        public static async Task WaitStateFinishAsync(this UnityEngine.Animator animator, string stateName, int layer = 0)
        {
            var asyncProxy = animator.GetOrAddComponent<AsyncAnimatorProxy>();
            var promiseSource = new AnimatorWaitStateFinishSource(animator, UnityEngine.Animator.StringToHash(stateName), layer);
            await asyncProxy.AddSource(promiseSource);
        }

        public static async Task WaitStateEnterAsync(this UnityEngine.Animator animator, string stateName, int layer = 0)
        {
            var asyncProxy = animator.GetOrAddComponent<AsyncAnimatorProxy>();
            var promiseSource = new AnimatorWaitStateEnterSource(animator, UnityEngine.Animator.StringToHash(stateName), layer);
            await asyncProxy.AddSource(promiseSource);
        }

        public static async Task WaitStateAsync(this Animator animator, string stateName, int layer = 0)
        {
            var asyncProxy = animator.GetOrAddComponent<AsyncAnimatorProxy>();
            var waitStateSource = new AnimatorWaitStateSource(animator, Animator.StringToHash(stateName), layer);
            await asyncProxy.AddSource(waitStateSource);
        }
    }
}

