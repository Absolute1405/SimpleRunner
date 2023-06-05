using System.Threading.Tasks;
using FlexEngine.Essence;
using FlexEngine.Essence.UnityExtensions;
using Runner.Level;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        private Direction _currentDirection;
        private Direction _startDirection;
        private IReadOnlySpeed _speed;
        private const float speedRotationMultiplier = 1f;

        public void Initialize(Direction startDirection, IReadOnlySpeed speed)
        {
            _startDirection = startDirection;
            _speed = speed;
        }
        
        public void OnRestart()
        {
            _currentDirection = _startDirection;
            Quaternion directionQuaternion = DirectionsMap.GetDirectionQuaternion(_currentDirection);
            SetRotation(directionQuaternion);
        }
        
        public async Task RotateTo(Direction direction)
        {
            Quaternion additionalDirection = DirectionsMap.GetDirectionQuaternion(direction);
            Quaternion targetQuaternion = transform.rotation.Add(additionalDirection);
            var time = 0f;

            while (true)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, time * _speed.CurrentValue * speedRotationMultiplier);
                await TimeAwaiter.WaitForSeconds(Time.deltaTime);
                time += Time.deltaTime;
                if (Mathf.Approximately(transform.rotation.eulerAngles.y, targetQuaternion.eulerAngles.y))
                    return;
            }

        }

        private void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}

