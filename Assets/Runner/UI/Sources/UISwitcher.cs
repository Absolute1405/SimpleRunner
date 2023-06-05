using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Runner.UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private UIScreen[] _screens;

        private UIScreen _currentScreen;

        public async Task SetScreen(UIScreenName name)
        {
            UIScreen screen = _screens.FirstOrDefault(x => x.ScreenName == name);

            if (screen == null)
                throw new InvalidEnumArgumentException($"Can find screen named {name}");

            if (_currentScreen != null)
                await _currentScreen.SetVisibleAsync(false);

            await screen.SetVisibleAsync(true);
            _currentScreen = screen;
        }
    }
}

