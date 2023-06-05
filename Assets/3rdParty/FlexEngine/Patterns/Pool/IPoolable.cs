using UnityEngine;

namespace FlexEngine.Patterns.Pool
{
    public interface IPoolable
    {
        bool Active { get; }
        void SetActive(bool value);
        void SetParent(Transform parent);
    }
}

