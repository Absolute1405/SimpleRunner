using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Runner.Level
{
    [Serializable]
    public class LevelChunksLineSettings
    {
        [SerializeField, Min(1)] private int _inlineChunksMinAmount = 6;
        [SerializeField, Min(2)] private int _inlineChunksMaxAmount = 12;
        [SerializeField] private AssetReference _template;

        public AssetReference Template => _template;

        public int GetRandomInlineChunksAmount()
        {
            return Random.Range(_inlineChunksMinAmount, _inlineChunksMaxAmount + 1);
            
            
        }

        public int InlineChunksMaxAmount => _inlineChunksMaxAmount;
    }
}

