using UnityEngine;
public class TargetCursor : MonoBehaviour
{ 
    private void Start()
    {
        gameObject.transform.position = Input.mousePosition;
    }
    private void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }
}
