using UnityEngine;
using UnityEngine.Serialization;

public class ReadInput : MonoBehaviour
{
    private NewInput _newInput;
    
    public Vector3 Direction;
    public float MouseDeltaX;
    public float MouseDeltaY;
    public float MouseClickLeftButton;
    public float MouseClickRihgtButton;
    public float KeyboardSpace;
    public float KeyboardF;
    
    private void Start()
    {
        _newInput = new NewInput();
        _newInput.Enable();
    }
    
    public void Read()
    {
        Direction = _newInput.Gameplay.Movement.ReadValue<Vector3>();
        MouseDeltaX = _newInput.Gameplay.MouseDeltaX.ReadValue<float>();
        MouseDeltaY = _newInput.Gameplay.MouseDeltaY.ReadValue<float>();
        MouseClickLeftButton = _newInput.Gameplay.MouseClickLeftButton.ReadValue<float>();
        MouseClickRihgtButton = _newInput.Gameplay.MouseClickRightButton.ReadValue<float>();
        KeyboardSpace = _newInput.Gameplay.Jump.ReadValue<float>();
        KeyboardF = _newInput.Gameplay.KeyboardF.ReadValue<float>();
    }
}
