using System;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Transform _characterCamera;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private Transform _targetPosition;//
   // [SerializeField] private Transform _startPosition;//

    private IMoving _moving;
    private IAbility _superJump;//
    private NewInput _newInput;
    
    
    private Vector3 _direction;
    private float _mouseDeltaX;
    private float _mouseDeltaY;
    private float _mouseClickLeftButton;
    private float _mouseClickRihgtButton;
    private float _keyboardSpace;
    private float _keyboardF;
    
    
    private void Start()
    {
        _moving = new CharacterModel(_characterController, _playerConfig, this, _groundChecker, _characterCamera);
        
        _superJump = new SuperJumpAbility(_characterController, _playerConfig);
        
        _newInput = new NewInput();
        _newInput.Enable();
    }

    private void FixedUpdate()
    {
        _moving.Move(_direction);
        
        if (_keyboardSpace != 0)
        {
            _moving.Jump();
        }
        
        _moving.RotateX(_mouseDeltaX);
        
        if (_mouseClickRihgtButton != 0)
        {
            _moving.RotateY(_mouseDeltaX, _mouseDeltaY);
        }
    }

    private void Update()
    {
        if (_keyboardF != 0)
        {
            StartCoroutine(_superJump.ExecuteAbility(_targetPosition));
        }
        ReadKeyboard();
        float moveSpeed = _characterController.velocity.magnitude;
        _animator.SetFloat("MoveSpeed", moveSpeed);
    }

    void ReadKeyboard()
    {
        _direction = _newInput.Gameplay.Movement.ReadValue<Vector3>();
        _mouseDeltaX = _newInput.Gameplay.MouseDeltaX.ReadValue<float>();
        _mouseDeltaY = _newInput.Gameplay.MouseDeltaY.ReadValue<float>();
        _mouseClickLeftButton = _newInput.Gameplay.MouseClickLeftButton.ReadValue<float>();
        _mouseClickRihgtButton = _newInput.Gameplay.MouseClickRightButton.ReadValue<float>();
        _keyboardSpace = _newInput.Gameplay.Jump.ReadValue<float>();
        _keyboardF = _newInput.Gameplay.KeyboardF.ReadValue<float>();
    }
}
