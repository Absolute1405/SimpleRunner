using FlexEngine.Essence.AppFlow;
using FlexEngine.Patterns.Pool;
using Runner.GameFlow;
using Runner.Level;
using Runner.Player.StateMachine;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerFacade : MonoBehaviour, IUpdatable, IRestartListener, IGameOverListener, IVictoryListener, IContinueListener, IFixedUpdatable, IPlayerInvulnerable, IPoolable
    {
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerPosition _playerPosition;
        [SerializeField] private PlayerInteraction _playerInteraction;
        [SerializeField] private PlayerTrapInteraction _trapInteraction;
        [SerializeField] private PlayerStatisticEnter _statisticEnter;
        [SerializeField] private PlayerRotation _playerRotation;
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private Transform _cameraFollowTarget;
        [SerializeField] private PlayerGroundCheck _groundCheck;
        
        public PlayerInteraction PlayerInteraction => _playerInteraction;
        public PlayerStatisticEnter StatisticEnter => _statisticEnter;

        public PlayerTrapInteraction TrapInteraction => _trapInteraction;

        public Transform CameraFollowTarget => _cameraFollowTarget;

        private PlayerStateMachine _stateMachine;

        private void OnEnable()
        {
            _playerInteraction.TurnTriggered += OnTurnTriggered;
            _groundCheck.OnGround += OnGrounded;
            _trapInteraction.ContinuePositionSaved += _playerPosition.CacheContinuePosition;
        }

        private void OnDisable()
        {
            _playerInteraction.TurnTriggered -= OnTurnTriggered;
            _groundCheck.OnGround -= OnGrounded;
            _trapInteraction.ContinuePositionSaved -= _playerPosition.CacheContinuePosition;
        }

        public void Initialize(PlayerConfig config, Vector3 startPosition, IReadOnlySpeed speed, Direction startDirection)
        {
            _stateMachine = new PlayerStateMachine(_animator, _playerPosition, _playerJump, _playerInteraction, _trapInteraction);
            
            _playerJump.Initialize(config.JumpForce);
            _playerPosition.Initialize(startPosition, speed);
            _playerRotation.Initialize(startDirection, speed);
            _groundCheck.Initialize();
        }

        private async void OnTurnTriggered(Direction direction)
        {
            _stateMachine.SetRotating();
            await _playerRotation.RotateTo(direction);
            _stateMachine.SetMoving();
        }

        public void SetEnabled(bool value) => enabled = value;

        public void DoUpdate()
        {
            if (!enabled)
                return;
            
            _playerPosition.DoUpdate();
        }

        public void OnRestart()
        {
            _playerRotation.OnRestart();
            _playerPosition.OnRestart();
            _stateMachine.SetInGame();
            _stateMachine.SetMoving();
        }

        public void OnJumpTriggered()
        {
            bool grounded = _groundCheck.Grounded;
            _playerJump.DoJump();

            if (grounded)
            {
                _stateMachine.SetJumping();
            }
            else
            {
                _stateMachine.SetDoubleJumping();
            }
        }
        
        public void SetInvulnerable(bool value)
        {
            if (value)
                _stateMachine.SetInvulnerable();
            else
                _stateMachine.SetVulnerable();
        }
        
        private void OnGrounded()
        {
            _stateMachine.OnGrounded();
        }

        public void OnGameOver()
        {
            _stateMachine.SetGameOver();
        }

        public void OnVictory()
        {
            _stateMachine.SetVictory();
        }

        public void OnContinue()
        {
            _playerPosition.OnContinue();
            _stateMachine.SetInGame();
            _stateMachine.SetMoving();
        }

        public void DoFixedUpdate()
        {
            _groundCheck.DoFixedUpdate();
        }

        public bool Active => gameObject.activeSelf;
        public void SetActive(bool value) => gameObject.SetActive(value);

        public void SetParent(Transform parent) => transform.SetParent(parent);
    }

    public interface IPlayerInvulnerable
    {
        void SetInvulnerable(bool value);
    }
}

