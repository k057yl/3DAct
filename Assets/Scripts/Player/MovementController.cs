using UnityEngine;

public class MovementController : IMovable, IJumping
{
    private CharacterController _characterController;
    
    
    public MovementController(CharacterController characterController)
    {
        _characterController = characterController;
    }
    
    public void Movening(Vector3 direction, float speed)
    {
        _characterController.Move(direction * (speed * Time.deltaTime));
    }

    public void Rotation(float mouseX)
    {
        _characterController.transform.Rotate(Vector3.up * mouseX);
    }

    public void DoGravity(Vector3 directionY, float velocity)
    {
        _characterController.Move(Vector3.up * (velocity * Time.fixedDeltaTime));
    }

    public void Jump(float velocity)
    {
        _characterController.Move(Vector3.up * (velocity * Time.deltaTime));
    }
}
