using System.Threading.Tasks;

namespace FlexEngine.Essence.Animations.Internal
{
    internal abstract class AnimatorSource
    {
        public Task SourceTask => _source.Task;
        private readonly TaskCompletionSource<bool> _source = new TaskCompletionSource<bool>();

        public void Complete()
        {
            _source.SetResult(true);
        }

        public abstract bool IsComplete();
    }
}

