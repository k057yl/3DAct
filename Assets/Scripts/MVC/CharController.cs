using System;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Transform _characterCamera;
    
    private float _moveSpeed = 5f;

    private IMoving _moving;
    //private CharacterView _characterView;
    private NewInput _newInput;
    
    
    private Vector3 _direction;
    private float _mouseDeltaX;
    private float _mouseDeltaY;
    private float _mouseClickLeftButton;
    private float _mouseClickRihgtButton;
    private float _keyboardSpace;
    private float _keyboardF;

    private bool _isGrounded;
    private float _velocity;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
       _moving = new CharacterModel(_characterController, _playerConfig, this, _groundChecker, _velocity, _characterCamera);
       //_characterView = GetComponent<CharacterView>();

        _newInput = new NewInput();
        _newInput.Enable();
    }

    private void FixedUpdate()
    {
        Move();
        if (_keyboardSpace != 0)
        {
            Jump();
        }
        Rotate();
    }

    private void Update()
    {
        ReadKeyboard();
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

    void Move()
    {
        _moving.Move(_direction, _moveSpeed);
    }

    void Jump()
    {
        _moving.Jump(_playerConfig.JumpHeight);
    }

    void Rotate()
    {
        _moving.Rotate(_mouseDeltaX, _mouseDeltaY);
    }
}
