using Runner.Shared;
using UnityEngine;

namespace Runner.Boosters
{
    public class BoosterFactory : AddressableCachedFactory<BoosterBase>
    {
        public float BoosterChance { get; private set; }
        
        public void Configure(float boosterChance)
        {
            BoosterChance = boosterChance;
        }
        
        public BoosterBase Create(Transform point)
        {
            BoosterBase booster = GetCachedInstance(point);
            return booster;
        }
    }
}

