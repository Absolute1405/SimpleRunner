using FlexEngine.Essence.Animations;
using FlexEngine.Essence.UI;
using Runner.Stats;
using UnityEngine;

namespace Runner.UI
{
    public class UIHealthView : MonoBehaviour
    {
        [SerializeField] private TextView _textView;
        [SerializeField] private BoolAnimator _visibleAnimator;
        [SerializeField] private TriggerAnimator _decreaseAnimator;

        private IHealth _health;

        public void Initialize(IHealth health)
        {
            _health = health;
            _health.Increased += HealthOnIncreased;
            _health.Decreased += HealthOnDecreased;
        }

        public void OnRestart()
        {
            _textView.SetText(_health.CurrentValue);
            _visibleAnimator.SetValue(true);
        }

        private async void HealthOnIncreased()
        {
            await _visibleAnimator.SetValueAsync(false);
            _textView.SetText(_health.CurrentValue);
            await _visibleAnimator.SetValueAsync(true);
        }

        private async void HealthOnDecreased()
        {
            _decreaseAnimator.Run();
            await _visibleAnimator.SetValueAsync(false);
            _textView.SetText(_health.CurrentValue);
            await _visibleAnimator.SetValueAsync(true);
        }

        private void OnDestroy()
        {
            _health.Increased -= HealthOnIncreased;
            _health.Decreased -= HealthOnDecreased;
        }
    }
}

