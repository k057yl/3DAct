using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Camera _cam;

   
    private Camera _camera;
    

    private void Awake()
    {
        //_playerController = Instantiate(_playerPrefab);
        _camera = Instantiate(_cam, transform.position, Quaternion.identity);
    }
}
