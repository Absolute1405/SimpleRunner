using System;
using UnityEngine;

namespace Runner.Shared
{
    [Serializable]
    public class GameSceneArgs
    {
        [SerializeField] private GameConfig _gameConfig;
        public GameConfig GameConfig => _gameConfig;
        
        public GameSceneArgs(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }
    }
}
