using UnityEngine;

public class PlayerModel : IPositionable
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
}
