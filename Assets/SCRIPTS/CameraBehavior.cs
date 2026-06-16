using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float cameraSpeed = 2f;
    public Transform target;

    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraSpeed * Time.deltaTime);
    }
}
