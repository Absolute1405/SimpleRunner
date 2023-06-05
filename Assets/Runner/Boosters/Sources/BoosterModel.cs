using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Boosters
{
    [CreateAssetMenu(menuName = "Runner/BoosterModel", fileName = "BoosterModel")]
    public class BoosterModel : ScriptableObject
    {
        [SerializeField] private AssetReference addressableTemplate;
        [SerializeField, Range(0, 1f)] private float _chance = 0.1f;
        
        public float Chance => _chance;

        public AssetReference AddressableTemplate => addressableTemplate;
    }
}

