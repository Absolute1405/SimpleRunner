using FlexEngine.Essence.Animations;
using UnityEngine;

namespace Runner.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private BoolAnimator _animator;
        [SerializeField] private UIScreenName _name;

        public UIScreenName ScreenName => _name;

        public void SetVisible(bool value)
        {
            _animator.SetValue(value);
        }
    }

    public enum UIScreenName
    {
        InGame,
        GameOver,
        Victory
    }
}

