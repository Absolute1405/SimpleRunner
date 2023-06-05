using System.Collections;
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
        
        //sorry for that ^_^
        private const float speedRotationMultiplier = 19f;

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
        
        public void RotateTo(Direction direction)
        {
            Quaternion additionalQuaternion = DirectionsMap.GetDirectionQuaternion(direction);
            Quaternion targetQuaternion = transform.rotation.Add(additionalQuaternion);
            StartCoroutine(RotationCoroutine(targetQuaternion));
        }

        private IEnumerator RotationCoroutine(Quaternion targetQuaternion)
        {
            while (true)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, _speed.CurrentValue * speedRotationMultiplier * Time.deltaTime);
                yield return null;
                if (Mathf.Approximately(transform.rotation.eulerAngles.y, targetQuaternion.eulerAngles.y))
                    break;
            }
        }

        private void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}

