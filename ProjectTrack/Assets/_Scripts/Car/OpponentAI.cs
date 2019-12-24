using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public Transform path;
    public Rigidbody sphereBody;
    private int currentNode = 1;
    private List<Transform> nodes = null;
    public float maxSpeed;
    public float maxForce;
    Vector3 sphereOffset;
    public float turnSpeed;
    public float smooth;

    void Start()
    {
        sphereOffset = transform.position - sphereBody.position;
        sphereBody.transform.parent = null;

    Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
      nodes = new List<Transform>();

      for (int i = 0; i < pathTransform.Length; i++)
      {
          if(pathTransform[i] != transform)
          {
            nodes.Add(pathTransform[i]);
          }
      }
    }

    void FixedUpdate()
    {
        ApplySteer();
        DistanceFromWaypoint();
    }

    Vector3 relativeVector;

    private void ApplySteer(){
        bool grounded = Physics.Raycast(transform.position, Vector2.down, out RaycastHit hit);
        relativeVector = sphereBody.transform.InverseTransformPoint(nodes[currentNode].position);
        sphereBody.AddRelativeForce((relativeVector/CalculateDistane(transform.position,nodes[currentNode].position)) * maxForce);
        sphereBody.velocity = Vector3.ClampMagnitude(sphereBody.velocity, maxSpeed);
        transform.position = sphereBody.position + sphereOffset;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(sphereBody.velocity, Vector3.up), (smooth * Time.deltaTime));
    }

    private void OnDrawGizmos() {
        if(currentNode > 1)
        {
            Gizmos.DrawLine(sphereBody.position,nodes[currentNode].position);
        }
    }
    
    private float CalculateDistane(Vector3 first, Vector3 second)
    {
        return Vector3.Distance(first,second);
    }


    private void DistanceFromWaypoint() {
        if(this.CalculateDistane(transform.position,nodes[currentNode].position) < 2f)
        {
            if(currentNode == nodes.Count-1)
            {
                currentNode = 1;
            }
            else
            {
                currentNode += 1;
            }
        }
    }
}
