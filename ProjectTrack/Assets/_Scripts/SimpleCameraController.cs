using UnityEngine;

public class SimpleCameraController : MonoBehaviour {

    public float cameraSpeed = 5f;

    public Transform target;
    public Vector3 offset;

    void FixedUpdate() {
        var targetPosition = target.position + (target.forward * offset.z + target.up * offset.y + transform.right * offset.x);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);

        transform.LookAt(target);
    }
}