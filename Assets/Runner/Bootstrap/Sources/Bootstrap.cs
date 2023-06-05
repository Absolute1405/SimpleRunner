using Runner.Shared;
using UnityEngine;

namespace Runner.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private ScenesController _scenesController;

        private void Awake()
        {
            DontDestroyOnLoad(_scenesController.gameObject);
            _scenesController.LoadGameScene(new GameSceneArgs(_gameConfig));
        }
    }
}

