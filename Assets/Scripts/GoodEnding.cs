using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnding : MonoBehaviour

{
    [SerializeField] GameObject endgameCanvas;
    [SerializeField] LawnmowerMover lawnmowerMover;
    //[SerializeField] private AudioSource roombaEnd;
    //[SerializeField] private AudioSource BackgroundMusicStops;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //roombaEnd.Play();
            //BackgroundMusicStops.Stop();
            endgameCanvas.SetActive(true);
            lawnmowerMover.StopAndCharge();
            
        }
    }
}
