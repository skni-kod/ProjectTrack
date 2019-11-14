using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFinishChecker : MonoBehaviour
{
    private bool orderChecker=true;
    private bool nie = false;
    private int i=1;
    public CheckPointChecker CheckPoint;


    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.name=="backDetector" && orderChecker == true  )
        {
            orderChecker = false;
            if (i == 1)
            {

                nie = true;
            }
            else if (i == 0)
            {
                nie = false;
            }

        }
        else if (coll.gameObject.name == "backDetector" && orderChecker == false )
        {
            if (nie == false)
            {
                orderChecker = true;
                nie = false;
            }
            else
                i--;

        }
        if (coll.gameObject.name == "frontDetector" && orderChecker == true)
        {
            if(CheckPoint.checkPoint ==true)
            {
                Debug.Log("Punkt");
                CheckPoint.checkPoint = false;
            } 
            nie = false;
            orderChecker = false;
        }
        else if (coll.gameObject.name == "frontDetector" && orderChecker ==false)
        {
            orderChecker = true;
            
        }
        
        
        

    }
    
    

}
