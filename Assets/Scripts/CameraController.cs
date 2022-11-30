using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _distanceFromTarget = 10f;
    [SerializeField] private float _mouseSensitivity = 3f;
    [SerializeField] private float _xSpeed = 80f;
    [SerializeField] private float _ySpeed = 80f;

    private float _x;
    private float _y;
    private float _targetX;
    private float _targetY;
    private float yMinLimit = -20f;
    private float yMaxLimit = 70f;
    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        _x = angles.y;
        _y = angles.x; 
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            _targetX += Input.GetAxis("Mouse X") * _xSpeed *  _mouseSensitivity;
            _targetY -= Input.GetAxis("Mouse Y") * _ySpeed * _mouseSensitivity;
        }
        _targetY = ClampAngle(_targetY, yMinLimit, yMaxLimit);
                
        _x = Mathf.LerpAngle(_x, _targetX,0.05f);
        _y = Mathf.LerpAngle(_y, _targetY, 0.05f);
            
        Quaternion rotation = Quaternion.Euler(_y, _x, 0);
            
        _camera.transform.rotation = rotation;
        _camera.transform.position = _cameraTarget.position - _camera.transform.forward * _distanceFromTarget;
    }
    
    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
