using System.Threading.Tasks;
using FlexEngine.Essence.Animations;
using UnityEngine;

namespace FlexEngine.Dialogs
{
    public abstract class Dialog<TArgs, TResult> : MonoBehaviour
    {
        [SerializeField] private BoolAnimator _animator;

        private TaskCompletionSource<TResult> _completionSource;

        public async Task<TResult> Run(TArgs args)
        {
            _completionSource = new TaskCompletionSource<TResult>();
            
            OnOpen(args);
            await _animator.SetValueAsync(true);
            
            var result = await _completionSource.Task;
            
            await _animator.SetValueAsync(false);
            OnClose(result);

            return result;
        }
        
        protected virtual void OnOpen(TArgs args) {}
        protected virtual void OnClose(TResult result) {}

        protected void SetResult(TResult result) => _completionSource.SetResult(result);
    }
}

