using System.Collections.Generic;
using System.Linq;
using Runner.Level;
using UnityEngine;

namespace Runner.Boosters
{
    public class LevelBoosterConstructor
    {
        private readonly BoosterFactory[] _boosterFactoriesSorted;
        private readonly BoostersConfig _config;

        public LevelBoosterConstructor(BoosterFactory[] boosterFactories, BoostersConfig config)
        {
            _boosterFactoriesSorted = boosterFactories;
            _config = config;
            
            var sortedFactories = new SortedList<float, BoosterFactory>();
            foreach (var boosterFactory in boosterFactories)
            {
                sortedFactories.Add(boosterFactory.BoosterChance, boosterFactory);
            }

            _boosterFactoriesSorted = sortedFactories.Values.ToArray();
        }

        public void FillWithBoosters(LevelChunk[] chunks)
        {
            foreach (var chunk in chunks)
            {
                if (!chunk.CanSpawnBooster)
                    continue;
                
                if (!CheckBoosterChance())
                    continue;

                BoosterFactory factory = ChooseBoosterFactoryByChance();
                BoosterBase booster = factory.Create(chunk.BoosterSpawnPoint);
                booster.SnapToParent();
            }
        }

        public void Clear()
        {
            foreach (var factory in _boosterFactoriesSorted)
            {
                factory.ReturnSpawnedInstancesToCache();
            }
        }

        private bool CheckBoosterChance()
        {
            float rand = Random.Range(0, 1f);
            return rand <= _config.BoosterAppearChance;
        }

        private BoosterFactory ChooseBoosterFactoryByChance()
        {
            float rand = Random.Range(0, 1f);

            foreach (var factoryByChance in _boosterFactoriesSorted)
            {
                if (factoryByChance.BoosterChance >= rand)
                {
                    return factoryByChance;
                }
            }
            
            Debug.LogError("Cant choose booster by chance. Created common booster");
            return _boosterFactoriesSorted[0];
        }
    }
}

