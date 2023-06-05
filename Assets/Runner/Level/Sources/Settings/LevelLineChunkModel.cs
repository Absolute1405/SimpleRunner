using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Level
{
    [CreateAssetMenu(menuName = "Runner/Level/LineChunkModel", fileName = "LevelLineChunkModel")]
    public class LevelLineChunkModel : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private LevelChunk _template;
        [SerializeField] private AssetReference _addressableTemplate;
        [SerializeField] private LevelChunkPriority _priority;
        [SerializeField] private AssetReference _uiPreview;
        [SerializeField] private bool _showInStatistic = true;
        [SerializeField] private bool _canSpawnBooster = false;

        public LevelChunk Template => _template;
        public LevelChunkPriority Priority => _priority;

        public AssetReference UIPreview => _uiPreview;

        public string ID => _id;

        public bool ShowInStatistic => _showInStatistic;

        public bool CanSpawnBooster => _canSpawnBooster;

        public AssetReference AddressableTemplate => _addressableTemplate;
    }
}

