using System;
using UnityEngine;

namespace Runner.Boosters
{
    [Serializable]
    public class BoostersConfig
    {
        [SerializeField] private BoosterModel[] _boosterModels;
        [SerializeField, Range(0,1f)] private float _boosterAppearChance = 0.3f;

        public BoosterModel[] BoosterModels => _boosterModels;
        public float BoosterAppearChance => _boosterAppearChance;
    }
}

