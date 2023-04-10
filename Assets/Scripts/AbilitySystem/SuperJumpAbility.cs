using UnityEngine;

public class SuperJumpAbility : IAbility
{
    private CharacterController _characterController;
    private Transform _targetPosirion;
    
    private Vector3 _startPosition;
    private float _jumpStartTime;

    public SuperJumpAbility(CharacterController characterController, Transform targetPosirion, Vector3 startPosition, float jumpStartTime)
    {
        _characterController = characterController;
        _targetPosirion = targetPosirion;
        _startPosition = startPosition;
        _jumpStartTime = jumpStartTime;
    }
    
    public void StartJump()
    {
        _startPosition = _characterController.transform.position;
        _jumpStartTime = Time.time;
    }
    
    public void ActivateAbility()
    {
        float timeSinceJumpStarted = Time.time - _jumpStartTime;
        float normalizedTime = Mathf.Clamp01(timeSinceJumpStarted / 1f);
        float jumpCurveValue = Mathf.Sin(normalizedTime * Mathf.PI);
 
        _characterController.transform.position = Vector3.Lerp(_startPosition, _targetPosirion.position, jumpCurveValue) + Vector3.up * 2f * jumpCurveValue;
    }

    public void DeactivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public void ExecuteAbility()
    {
        throw new System.NotImplementedException();
    }
}
