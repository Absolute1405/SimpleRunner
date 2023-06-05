using Runner.Boosters;
using Runner.Level;
using Runner.Level.Settings;
using Runner.Player;
using Runner.Stats;
using UnityEngine;

namespace Runner.Shared
{
    [CreateAssetMenu(menuName = "Runner/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private StatsConfig _statsConfig;
        
        [Space(10f)]
        [Header("Level Settings")]
        [SerializeField] private LevelChunksSettings _levelChunksSettings;
        [SerializeField] private LevelChunksLineSettings _levelChunksLineSettings;
        [SerializeField, Min(2)] private int _linesAmount;
        [SerializeField] private Direction _startDirection = Direction.Forward;
        [SerializeField] private BoostersConfig _boostersConfig;
        
        public PlayerConfig PlayerConfig => _playerConfig;

        public LevelSettings LevelSettings => new LevelSettings(_levelChunksSettings, _levelChunksLineSettings, _boostersConfig, _linesAmount);

        public Direction StartDirection => _startDirection;
        public StatsConfig StatsConfig => _statsConfig;
    }

}

