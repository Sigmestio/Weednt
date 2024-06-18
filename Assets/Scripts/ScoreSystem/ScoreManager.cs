using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public GameObject goodEndingCanvas;
    public SceneConfigsSO sceneData;
    private int currentWeedsKilled = 0;
    private int routeMoves = 0;
    private int currentTotalPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        currentWeedsKilled = 0;
        routeMoves = 0;
        currentTotalPoints = 0;
        goodEndingCanvas.SetActive(false);
    }

    public void AddCleanedDirt()
    {
        currentWeedsKilled++;
        if (currentWeedsKilled == sceneData.redWeeds)
        {
            CheckForGoodEnding();
        }
    }

    public void AddRouteMoves()
    {
        routeMoves++;
    }

    public void DeleteRouteMoves()
    {
        routeMoves--;
    }

    private void CheckForGoodEnding()
    {
        if (currentWeedsKilled == sceneData.redWeeds && routeMoves <= sceneData.maxArrows)
        {
            ActivateGoodEnding();
        }
    }

    private void ActivateGoodEnding()
    {
        goodEndingCanvas.SetActive(true);
    }

    public void CalculateScore()
    {
        currentTotalPoints = 0;

        if (currentWeedsKilled >= sceneData.redWeeds)
        {
            currentTotalPoints++;
        }

        if (currentTotalPoints >= 1 && routeMoves <= sceneData.maxArrows)
        {
            currentTotalPoints++;
        }
    }

    public void EndLevel()
    {
        CalculateScore();
        CheckForGoodEnding();
    }
}

