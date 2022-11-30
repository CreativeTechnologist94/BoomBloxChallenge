using UnityEngine;
using UnityEngine.UI;
public class RadialSpeedIndicator : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;
    [SerializeField] private Image _radialIndicatorUI;
    private void Start()
    {
        _radialIndicatorUI.enabled = false;
    }
    private void Update()
    {
        if (_shootController.leftKeyPressed == true)
        {
            _radialIndicatorUI.enabled = true;
            _radialIndicatorUI.transform.position = Input.mousePosition;
            _radialIndicatorUI.fillAmount = (_shootController._ballSpeed - _shootController._initialBallSpeed)/ 100;
        }
        else
        {
            _radialIndicatorUI.enabled = false;
        }
    }
}
