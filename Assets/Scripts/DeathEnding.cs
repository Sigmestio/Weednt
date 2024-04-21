using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnding : MonoBehaviour
{
    [SerializeField] GameObject badEndgameCanvas;
    [SerializeField] LawnmowerMover lawnmowerMover;
    //[SerializeField] private AudioSource roombaEnd;
    //[SerializeField] private AudioSource BackgroundMusicStops;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //roombaEnd.Play();
            //BackgroundMusicStops.Stop();
            badEndgameCanvas.SetActive(true);
            lawnmowerMover.StopAndDie();
            
        }
    }
}
