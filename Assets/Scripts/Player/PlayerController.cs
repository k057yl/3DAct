using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const int VELOCITY_DECREASEMENT = -2;
    
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Transform _targetPosition;
    
    private IMovable _movementController;
    private IPositionable _playerModel;
    private IJumping _jumping;//-----------------
    private AbilitySystem _abilitySystem;
    private ReadInput _readInput;
    
    private float _xRotation;
//----------  
    private float _velocity;
    private bool _isGrounded;
    
    private Vector3 _startPosition;
    private float _jumpStartTime;
//----------------
    private void Start()
    {
        CharacterController _characterController = GetComponent<CharacterController>();
        _movementController = new MovementController(_characterController);
        
        _jumping = new MovementController(_characterController);//----------------------

        _playerModel = new PlayerModel();
        
        _readInput = GetComponent<ReadInput>();
        
        _abilitySystem = GetComponent<AbilitySystem>();
        _abilitySystem.SetAbility(new SuperJumpAbility(_characterController, _targetPosition, _startPosition, _jumpStartTime));
        
//-------------
        _startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _isGrounded = IsOnGround();
        if (_isGrounded && _velocity < 0)
        {
            _velocity = VELOCITY_DECREASEMENT;
        }
        Move();
        Rotation();
        DoGravity();
    }

    private void Update()
    {
        _readInput.Read();
        DirectionModel();
        if (_readInput.KeyboardSpace != 0)
        {
            Jump();
        }

        if (_readInput.KeyboardF != 0)
        {
            _abilitySystem.ActivateAbility();
        }
    }
    
    void Move()
    {
        var characterTransform = transform;
        _readInput.Direction = characterTransform.right * _readInput.Direction.x + characterTransform.forward * _readInput.Direction.z;
        
        _movementController.Movening(_readInput.Direction, _playerConfig.Speed);
    }

    void DirectionModel()
    {
        _playerModel.Position = transform.position;
        _playerModel.Rotation = transform.rotation;
    }

    void CameraRotate()
    {
        if (_readInput.MouseClickRihgtButton != 0)
        {
            _xRotation -= _readInput.MouseDeltaY;
        }
        
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
    void Rotation()
    {
        CameraRotate();
        _movementController.Rotation(_readInput.MouseDeltaX);
    }
    
    private void DoGravity()
    {
        _velocity += _playerConfig.Gravity * Time.fixedDeltaTime;
        
        _jumping.DoGravity(_readInput.Direction , _velocity);
    }

    private bool IsOnGround()
    {
        bool result = Physics.CheckSphere(
            _groundChecker.position,
            _playerConfig.GroundCheckRadius,
            _playerConfig.GroundMask);
        return result;
    }
    
    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity = Mathf.Sqrt(_playerConfig.JumpHeight * VELOCITY_DECREASEMENT * _playerConfig.Gravity);
            _jumping.Jump(_velocity);
        }
    }
//----------
    
}
