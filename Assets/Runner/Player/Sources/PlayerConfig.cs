using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Player
{
    [Serializable]
    public class PlayerConfig
    {
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private AssetReference _playerTemplate;

        public AssetReference PlayerTemplate => _playerTemplate;

        public float JumpForce => _jumpForce;
    }
}
