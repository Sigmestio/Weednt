using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnding : MonoBehaviour

{
    [SerializeField] GameObject endgameCanvas;
    [SerializeField] LawnmowerMover lawnmowerMover;
    [SerializeField] private AudioSource happyMusic;
    [SerializeField] private AudioSource BackgroundMusicStops;
    [SerializeField] private AudioSource lawnmowerStops;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            happyMusic.Play();
            BackgroundMusicStops.Stop();
            lawnmowerStops.Stop();
            ScoreManager.Instance.EndLevel();
            endgameCanvas.SetActive(true);
          
            
        }
    }
}
