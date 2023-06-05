using UnityEngine;

namespace Runner.Shared
{
    public class GameTestSceneRunner : MonoBehaviour
    {
        [SerializeField] private GameSceneRunner _sceneRunner;
        [SerializeField] private GameSceneArgs _args;
        [SerializeField] private bool _runOnAwake;

        private async void Awake()
        {
            if (!_runOnAwake)
                return;
            
            await _sceneRunner.Load(_args);
            _sceneRunner.Run(_args);
        }
    }
    
    
}

