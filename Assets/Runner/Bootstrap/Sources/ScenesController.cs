using FlexEngine.Essence.Animations;
using FlexEngine.Essence.ScenesManagement;
using Runner.Shared;
using UnityEngine;

namespace Runner.Bootstrap
{
    public class ScenesController : MonoBehaviour
    {
        [SerializeField] private string _gameSceneName;
        [SerializeField] private BoolAnimator _loadingScreenAnimator;
        [SerializeField] private ScenesLoader _scenesLoader;

        public async void LoadGameScene(GameSceneArgs args)
        {
            _loadingScreenAnimator.SetValue(true);
            await _scenesLoader.LoadScene(_gameSceneName, args);
            _loadingScreenAnimator.SetValue(false);
        }

    }
}

