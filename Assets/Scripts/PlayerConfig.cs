using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerStatsConfig",menuName = "Configs")]
public class PlayerConfig : ScriptableObject
{
    public float Gravity = -9.81f;
    public float JumpHeight;
    public float Speed;
    public LayerMask GroundMask;
    public float GroundCheckRadius;
}