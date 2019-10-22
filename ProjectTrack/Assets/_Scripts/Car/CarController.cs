using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour {

    public LayerMask trackMask;
    public float rayLength;
    public Rigidbody sphereBody;

    public float maxSpeed;

    public float forceMultiplier;
    public float turnSpeed;

    Vector3 sphereOffset;

    Vector2 inputVector;

    void Awake() {
        sphereOffset = transform.position - sphereBody.position;
        sphereBody.transform.parent = null;
    }

    void OnMove(InputValue input) {
        inputVector = input.Get<Vector2>();
    }

    void FixedUpdate() {
        transform.position = sphereBody.position + sphereOffset;

        bool grounded = Physics.Raycast(transform.position, Vector2.down, out RaycastHit hit, rayLength, trackMask);
        if (grounded) {
            var groundNormal = hit.normal;
            var forwardVector = Vector3.Cross(transform.right, groundNormal);

            transform.rotation = Quaternion.LookRotation(forwardVector, groundNormal);

            var forceVector = transform.forward * forceMultiplier * inputVector.y;

            sphereBody.AddForce(forceVector);
            sphereBody.velocity = Vector3.ClampMagnitude(sphereBody.velocity, maxSpeed);

            transform.Rotate(transform.up * inputVector.x * turnSpeed);
        }
    }

    void OnGUI() {
        GUILayout.Label(sphereBody.velocity.magnitude.ToString());
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }
}