using UnityEngine;

public class SuperJumpAbility : IAbility
{
    
    private CharacterController _characterController;
    private PlayerConfig _playerConfig;
    private CharController _charController;
    private Transform _targetPosition;
    private Vector3 _target;//
    private Transform _start;//
    private Vector3 _startPosition;

    public SuperJumpAbility(CharacterController characterController, PlayerConfig playerConfig, CharController charController,
        Transform targetPosition, Vector3 startPosition)
    {
        _characterController = characterController;
        _playerConfig = playerConfig;
        _charController = charController;
        _targetPosition = targetPosition;
        _startPosition = startPosition;
    }
    
    public SuperJumpAbility(CharacterController characterController, PlayerConfig playerConfig, Transform start,
        Transform targetPosition)
    {
        _characterController = characterController;
        _playerConfig = playerConfig;
        _start = start;
        _targetPosition = targetPosition;
    }
    
    
    public void ActivateAbility()
    {
        Vector3 direction = (_targetPosition.position - _start.position).normalized;

        _characterController.SimpleMove( new Vector3(direction.x, 0f, direction.z) * _playerConfig.Speed);
    }

    public void DeactivateAbility()
    {
        
    }

    public void ExecuteAbility()
    {
        
    }
    
}
