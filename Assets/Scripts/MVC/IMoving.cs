using UnityEngine;

public interface IMoving
{
    void Move(Vector3 direction, float speed);
    void Jump(float jumpHeight);
    void Rotate(float mouseDeltaX, float mouseDeltaY);

}

