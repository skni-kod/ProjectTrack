using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointChecker : MonoBehaviour
{
    public bool checkPoint=false;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "frontDetector")
        {
            checkPoint = true;
            
        }

    }
}
