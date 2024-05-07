using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLawnmowerRotation : MonoBehaviour
{
    private bool hasTriggered = false;

    private void Start()
    {
        Debug.Log(transform.forward, this);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (!hasTriggered)
        {
            LawnmowerMover lawnmowerMovement = other.GetComponent<LawnmowerMover>();

            if (lawnmowerMovement != null)
            {
                lawnmowerMovement.RotateLawnmower(transform.forward);

                hasTriggered = true;
              
            }
        }
        
    }
}