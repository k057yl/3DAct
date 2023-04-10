using UnityEngine;

public interface IMovable
{
    void Movening(Vector3 direction, float speed);
    void Rotation(float mouseX);
}
