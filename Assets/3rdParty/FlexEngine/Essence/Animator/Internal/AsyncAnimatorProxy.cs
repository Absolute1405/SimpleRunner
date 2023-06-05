using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FlexEngine.Essence.Animations.Internal
{
    internal class AsyncAnimatorProxy : MonoBehaviour
    {
        private readonly List<AnimatorSource> _sources = new List<AnimatorSource>();
        private readonly List<AnimatorSource> _completeSources = new List<AnimatorSource>();

        public async Task AddSource(AnimatorSource source)
        {
            _sources.Add(source);
            enabled = true;
            await source.SourceTask;
        }

        private void LateUpdate()
        {
            _completeSources.Clear();

            for (var i = _sources.Count - 1; i >= 0; i--)
            {
                var source = _sources[i];
                if (!source.IsComplete()) continue;
                _completeSources.Add(source);
                _sources.RemoveAt(i);
            }

            foreach (var completeSource in _completeSources)
            {
                completeSource.Complete();
            }

            if (_sources.Count == 0)
            {
                enabled = false;
            }
        }
    }
}

