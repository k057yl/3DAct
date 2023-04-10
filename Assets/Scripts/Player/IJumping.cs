using UnityEngine;
public interface IJumping
{
    void DoGravity(Vector3 directionY, float velocity);
    void Jump(float velocity);
}
