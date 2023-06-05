using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Level
{
    [CreateAssetMenu(menuName = "Runner/Level/EndChunkModel", fileName = "LevelEndChunkModel")]
    public class LevelEndChunkModel : ScriptableObject
    {
        [SerializeField] private LevelChunk _template;
        [SerializeField] private AssetReference _addressableTemplate;


        public LevelChunk Template => _template;

        public AssetReference AddressableTemplate => _addressableTemplate;
    }
}
