using UnityEngine;

public class CameraController : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = PlayerManager.Instance.currentController.transform.position +
            new Vector3(4, 4, 0);
    }
}
