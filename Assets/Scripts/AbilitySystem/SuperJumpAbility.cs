using System.Collections;
using UnityEngine;

public class SuperJumpAbility : IAbility
{
    private CharacterController _characterController;
    private PlayerConfig _playerConfig;
    
    public SuperJumpAbility(CharacterController controller, PlayerConfig playerConfig)
    {
        _characterController = controller;
        _playerConfig = playerConfig;
    }
    
    public void ActivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public void DeactivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator ExecuteAbility(Transform targetTransform)
    {
        Vector3 startPosition = _characterController.transform.position;
        Vector3 targetPosition = targetTransform.position;
        float distance = Vector3.Distance(startPosition, targetPosition);

        float timeToJump = Mathf.Sqrt(2f * _playerConfig.JumpHeight / Physics.gravity.magnitude) + Mathf.Sqrt(2f * (distance - _playerConfig.JumpHeight) / Physics.gravity.magnitude);
        float jumpVelocity = Mathf.Sqrt(2f * Physics.gravity.magnitude * _playerConfig.JumpHeight);

        float elapsedTime = 0f;
        while (elapsedTime < timeToJump)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / timeToJump;
            Vector3 nextPosition = Vector3.Lerp(startPosition, targetPosition, t);
            nextPosition.y = startPosition.y + jumpVelocity * t - 0.5f * Physics.gravity.magnitude * t * t;
            _characterController.Move(nextPosition - _characterController.transform.position);
            yield return null;
        }
    }
}
