using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Runner.UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private UIScreen[] _screens;

        private UIScreen _currentScreen;

        public void SetScreen(UIScreenName name)
        {
            UIScreen screen = _screens.FirstOrDefault(x => x.ScreenName == name);

            if (screen == null)
                throw new InvalidEnumArgumentException($"Can find screen named {name}");

            if (_currentScreen != null)
                _currentScreen.SetVisible(false);

            screen.SetVisible(true);
            _currentScreen = screen;
        }
    }
}

