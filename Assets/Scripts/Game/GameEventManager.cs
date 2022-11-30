 using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI  _levelCompleteText;
    [SerializeField] private GameObject _blockStack;
    [HideInInspector] public float score = 0f;
    private float _blocksCount;
    private void Start()
    {
        _blocksCount = _blockStack.transform.childCount;
        _levelCompleteText.text = string.Empty;
    }
    private void Update()
    {
        _playerScoreText.text = "Score: " + score + " / " + _blocksCount;
        
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (score != _blocksCount) return;
        _levelCompleteText.text = "Level Completed<br>Press 'R' to Restart";
        if (Input.GetKeyDown("r"))
        {
            RestartScene();
        }
        
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
