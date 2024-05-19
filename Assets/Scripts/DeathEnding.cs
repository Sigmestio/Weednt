using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnding : MonoBehaviour
{
    [SerializeField] GameObject badEndgameCanvas;
    [SerializeField] LawnmowerMover lawnmowerMover;
    [SerializeField] private AudioSource sadMusic;
    [SerializeField] private AudioSource BackgroundMusicStops;
    [SerializeField] private AudioSource lawnmowerStops;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sadMusic.Play();
            BackgroundMusicStops.Stop();
            lawnmowerStops.Stop();
            badEndgameCanvas.SetActive(true);
            lawnmowerMover.StopAndDie();
            
        }
    }
}
