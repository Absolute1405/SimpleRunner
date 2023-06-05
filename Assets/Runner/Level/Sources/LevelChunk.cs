using UnityEngine;

namespace Runner.Level
{
    public class LevelChunk : MonoBehaviour, IBoosterPlace
    {
        [SerializeField] private Transform _nextConnectionPoint;
        [SerializeField] private Transform _previousConnectionPoint;
        [SerializeField] private Transform _boosterSpawnPoint;

        public LevelConnectionPoint NextConnectionPoint => _nextConnectionPoint.ConvertToConnectionPoint();
        public bool CanSpawnBooster { get; private set; }
        public Transform BoosterSpawnPoint => _boosterSpawnPoint;

        public void Initialize(bool canSpawnBooster)
        {
            CanSpawnBooster = canSpawnBooster;
        }

        public void ConnectWithPoint(LevelConnectionPoint point)
        {
            transform.localRotation = point.Rotation;
            transform.localPosition = point.Position - _previousConnectionPoint.position;
        }

        public bool Active => gameObject.activeSelf;

        public void SetActive(bool value) => gameObject.SetActive(value);

        public void SetParent(Transform parent) => transform.SetParent(parent);
    }

    public interface IBoosterPlace
    {
        bool CanSpawnBooster {get;}
        Transform BoosterSpawnPoint { get; }
    }
}

