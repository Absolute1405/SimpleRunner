using Cinemachine;
using UnityEngine;

namespace Runner.Shared
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;

        public void SetFollowTarget(Transform target)
        {
            _cinemachineCamera.Follow = target;
            _cinemachineCamera.LookAt = target;
        }
    }
}

