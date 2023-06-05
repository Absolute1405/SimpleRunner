using System.Threading.Tasks;
using FlexEngine.Essence.Animations;
using UnityEngine;

namespace Runner.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private BoolAnimator _animator;
        [SerializeField] private UIScreenName _name;

        public UIScreenName ScreenName => _name;

        public async Task SetVisibleAsync(bool value)
        {
            await _animator.SetValueAsync(value);
        }
    }

    public enum UIScreenName
    {
        InGame,
        GameOver,
        Victory
    }
}

