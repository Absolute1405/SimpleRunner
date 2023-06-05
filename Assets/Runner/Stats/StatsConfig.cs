using System;
using UnityEngine;

namespace Runner.Stats
{
    [Serializable]
    public class StatsConfig
    {
        [SerializeField, Min(1f)] private float _basicSpeed = 5f;
        [SerializeField, Min(2f)] private float _boostedSpeed = 8f;
        [SerializeField, Min(0.5f)] private float _speedBoostDuration = 5f;
        [SerializeField, Min(0.5f)] private float _speedContinueSlowDuration = 5f;
        [SerializeField, Min(0.5f)] private float _continueSpeed = 2.5f;

        [SerializeField, Min(0.5f)] private float _invulnerableDuration = 3f;
        [SerializeField, Min(1)] private int _baseHealth = 3;
        [SerializeField, Min(1)] private int _boosterHealthRegen = 1;
        [SerializeField, Min(1)] private int _continueHealth = 1;

        public float BasicSpeed => _basicSpeed;

        public float BoostedSpeed => _boostedSpeed;

        public float InvulnerableDuration => _invulnerableDuration;

        public int BaseHealth => _baseHealth;

        public int BoosterHealthRegen => _boosterHealthRegen;

        public int ContinueHealth => _continueHealth;

        public float SpeedBoostDuration => _speedBoostDuration;

        public float SpeedContinueSlowDuration => _speedContinueSlowDuration;

        public float ContinueSpeed => _continueSpeed;
    }
}

