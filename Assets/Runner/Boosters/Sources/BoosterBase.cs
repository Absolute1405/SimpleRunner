using FlexEngine.Essence.Animations;
using FlexEngine.Patterns.Pool;
using Runner.Player;
using UnityEngine;

namespace Runner.Boosters
{
    [RequireComponent(typeof(Collider))]
    public abstract class BoosterBase : MonoBehaviour, IPoolable
    {
        [SerializeField] private TriggerAnimator _animator;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IPlayerInteraction>(out var player))
            {
                _animator.Run();
                OnBoosterPicked(player);
            }
        }

        protected abstract void OnBoosterPicked(IPlayerInteraction player);

        public bool Active => gameObject.activeSelf;
        public void SetActive(bool value) => gameObject.SetActive(value);

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void SnapToParent()
        {
            transform.localPosition = Vector3.zero;
        }
    }
}

