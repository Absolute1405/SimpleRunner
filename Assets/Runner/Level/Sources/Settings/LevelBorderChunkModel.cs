using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Level
{
    [CreateAssetMenu(menuName = "Runner/Level/BorderChunkModel", fileName = "LevelBorderChunkModel")]
    public class LevelBorderChunkModel : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private LevelChunk _template;
        [SerializeField] private AssetReference _addressableTemplate;

        public LevelChunk Template => _template;
        public string ID => _id;

        public AssetReference AddressableTemplate => _addressableTemplate;
    }
}

