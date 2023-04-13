using UnityEngine;

public class CharacterModel : IMoving
{
    private const int VELOCITY_DECREASEMENT = -2;
    
    private CharacterController _characterController;
    private PlayerConfig _playerConfig;
    private CharController _charController;
    private Transform _characterCamera;

    private Transform _groundChecker;
    private float _velocity;
    private float _mouseDeltaX;
    private float _mouseDeltaY;
    private float _xRotation;

    public CharacterModel(CharacterController characterController, PlayerConfig playerConfig, CharController charController, Transform groundChecker, Transform characterCamera)
    {
        _characterController = characterController;
        _playerConfig = playerConfig;
        _charController = charController;
        _groundChecker = groundChecker;
        _characterCamera = characterCamera;
    }
    
    public void Move(Vector3 direction)
    {
        DoGravity();
        
        var characterTransform = _charController.transform;
        direction = characterTransform.right * direction.x + characterTransform.forward * direction.z;
        
        _characterController.Move(direction * (_playerConfig.Speed * Time.deltaTime));
    }

    public void RotateX(float mouseDeltaX)
    {
        _mouseDeltaX = mouseDeltaX;
        
        _charController.transform.Rotate(Vector3.up * mouseDeltaX);
    }

    public void RotateY(float mouseDeltaX, float mouseDeltaY)
    {
        _mouseDeltaX = mouseDeltaX;
        _mouseDeltaY = mouseDeltaY;
        
        _xRotation -= _mouseDeltaY;

        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        _characterCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _charController.transform.Rotate(Vector3.up * _mouseDeltaX);
    }
    
    public void Jump()
    {
        bool isGrounded = IsGround();
        if (isGrounded)
        {
            _velocity = Mathf.Sqrt(_playerConfig.JumpHeight * VELOCITY_DECREASEMENT * _playerConfig.Gravity);
        }
    }

    public void DoGravity()
    {
        _velocity += _playerConfig.Gravity * Time.fixedDeltaTime;
        
        _characterController.Move(Vector3.up * (_velocity * Time.fixedDeltaTime));
    }

    public bool IsGround()
    {
        bool result = Physics.CheckSphere(
            _groundChecker.position,
            _playerConfig.GroundCheckRadius,
            _playerConfig.GroundMask);
        return result;
    }
}
