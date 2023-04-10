using System;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;
    
    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Quaternion Rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }
    
    private void FixedUpdate()
    {
        UpdateAnimator();
    }

    public void SetMovementInput(Vector3 movementInput)
    {
        Position = movementInput;
    }

    private void UpdateAnimator()
    {
        
        float moveSpeed = _characterController.velocity.magnitude;
        _animator.SetFloat("MoveSpeed", moveSpeed);
    }
}
