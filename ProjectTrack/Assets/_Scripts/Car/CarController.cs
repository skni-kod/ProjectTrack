using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public Rigidbody sphereBody;

    public float maxSpeed;

    public float forceMultiplier;
    public float turnSpeed;

    Vector3 sphereOffset;

    void Awake() {
        sphereOffset = transform.position - sphereBody.position;
        sphereBody.transform.parent = null;
    }

    void FixedUpdate() {
        var horizontal = Input.GetAxis("Horizontal");
        var verical = Input.GetAxis("Vertical");

        float forceValue = Mathf.Clamp(forceMultiplier * verical, 0, maxSpeed);
        var forceVector = transform.forward * forceValue;

        sphereBody.AddForce(forceVector);
        transform.Rotate(0, horizontal * turnSpeed, 0);

        transform.position = sphereBody.position + sphereOffset;
    }
}