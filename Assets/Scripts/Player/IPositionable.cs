using UnityEngine;

public interface IPositionable
{
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
}
