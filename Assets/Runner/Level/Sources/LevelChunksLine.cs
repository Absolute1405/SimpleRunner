using System.Collections.Generic;
using FlexEngine.Patterns.Pool;
using UnityEngine;

namespace Runner.Level
{
    public class LevelChunksLine : MonoBehaviour, IMovable, IPoolable
    {
        public LevelConnectionPoint LineConnectionPoint => EndChunk.NextConnectionPoint;
        public IReadOnlyList<LevelChunk> LineChunks => _lineChunks;
        public LevelChunk EndChunk { get; private set; }
        
        private List<LevelChunk> _lineChunks = new List<LevelChunk>();

        public void SetStartPoint(LevelConnectionPoint point)
        {
            transform.localPosition = point.Position;
            transform.localRotation = point.Rotation;
        }

        public void FillWithChunks(IEnumerable<LevelChunk> chunks, LevelChunk endChunk)
        {
            _lineChunks = new List<LevelChunk>();
            var connectionPoint = transform.ConvertToConnectionPoint();

            foreach (var chunk in chunks)
            {
                chunk.ConnectWithPoint(connectionPoint);
                chunk.SetParent(transform);
                connectionPoint = chunk.NextConnectionPoint;
                _lineChunks.Add(chunk);
            }
            
            endChunk.ConnectWithPoint(connectionPoint);
            endChunk.SetParent(transform);
            EndChunk = endChunk;
        }

        public void Move(Vector3 movement)
        {
            transform.Translate(movement * Time.deltaTime);
        }

        public bool Active => gameObject.activeSelf;
        public void SetActive(bool value) => gameObject.SetActive(value);
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
    }

    public interface IMovable
    {
        void Move(Vector3 movement);
    }
}

