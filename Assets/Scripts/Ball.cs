using UnityEngine;
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRigidbody;
    public void LaunchBall(Vector3 direction, float speed )
    {
        _ballRigidbody.AddForce(direction * speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.1f);
    }
}
