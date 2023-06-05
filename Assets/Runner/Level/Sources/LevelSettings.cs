using System;
using Runner.Boosters;

namespace Runner.Level.Settings
{
    [Serializable]
    public class LevelSettings
    {
        public LevelChunksSettings LevelChunksSettings { get; }
        public LevelChunksLineSettings LevelChunksLineSettings { get; }
        public BoostersConfig BoostersConfig { get; }
        public int LinesAmount { get; }

        public LevelSettings(LevelChunksSettings levelChunksSettings, LevelChunksLineSettings levelChunksLineSettings, BoostersConfig boostersConfig, int linesAmount)
        {
            LevelChunksSettings = levelChunksSettings;
            LevelChunksLineSettings = levelChunksLineSettings;
            BoostersConfig = boostersConfig;
            LinesAmount = linesAmount;
        }
    }
}

