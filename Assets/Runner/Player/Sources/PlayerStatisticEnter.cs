using System;
using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerStatisticEnter : MonoBehaviour, IPlayerStatisticsEnter, IPlayerChunkCrossed, IEnablable
    {
        public event Action<string> ChunkCrossed;
        public void OnChunkCrossed(string id)
        {
            if (!enabled)
                return;
            ChunkCrossed?.Invoke(id);
        }

        public void SetEnabled(bool value)
        {
            enabled = value;
        }
    }
    
    public interface IPlayerStatisticsEnter
    {
        event Action<string> ChunkCrossed;
    }
    
    public interface IPlayerChunkCrossed
    {
        void OnChunkCrossed(string id);
    }
}
