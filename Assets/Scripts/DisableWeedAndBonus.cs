using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWeedAndBonus : MonoBehaviour
{
    private bool hasTriggered = false;

    //[SerializeField] private AudioSource lawnmowerEat; 

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            LawnmowerMover lawnmowerMover = other.GetComponent<LawnmowerMover>();
            if (lawnmowerMover != null)
            {
                hasTriggered = true;
                DisableMesh();
                //lawnmowerEat.Play();

            }
        }
    }

    void DisableMesh()
    {
        Renderer meshRenderer = GetComponent<Renderer>();

        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

    bool IsMeshEnabled()
    {
        Renderer meshRenderer = GetComponent<Renderer>();
        return meshRenderer != null && meshRenderer.enabled;
    }
}
