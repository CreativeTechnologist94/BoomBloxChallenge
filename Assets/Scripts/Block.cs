using UnityEngine;
public class Block : MonoBehaviour
{
    [SerializeField] private GameEventManager _gameManager;
    private bool _blockDestroyed = false;
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground")) return;
        if (_blockDestroyed == true) return;
        Destroy(gameObject, 0.2f);
        _blockDestroyed = true;
        _gameManager.score++;
    }
}
