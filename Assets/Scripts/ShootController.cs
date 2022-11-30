using UnityEngine;
public class ShootController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _speedIncrementValue = 20f;
    [SerializeField] private float _maxBallSpeed = 110f;
    [HideInInspector] public float _ballSpeed;
    [HideInInspector] public bool leftKeyPressed = false;
    public float _initialBallSpeed = 10f;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            leftKeyPressed = true;
            CalculateBallSpeed();
        }

        if (Input.GetMouseButtonUp(0))
        {
            leftKeyPressed = false;
            ShootBall();
            ResetBallSpeed();
        }
    }

    private void CalculateBallSpeed()
    {
        if (_ballSpeed < _maxBallSpeed)
        {
            _ballSpeed += _speedIncrementValue * Time.deltaTime;
        }
    }

    private void ShootBall()
    {
        var mousePos = Input.mousePosition;
        var ray = _mainCamera.ScreenPointToRay(mousePos);

        var spawnedBall = Instantiate(_ballPrefab, ray.origin, _mainCamera.transform.rotation);
        spawnedBall.GetComponent<Ball>().LaunchBall(ray.direction, _ballSpeed);
    }
    
    private void ResetBallSpeed()
    {
        _ballSpeed = 0f;
    }
}
