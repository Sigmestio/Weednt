using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public LevelLoader levelLoader;
    public SceneConfigsSO sceneData;
    private int currentWeedsKilled = 0;
    private int routeMoves = 0;
    private int currentTotalPoints = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
       currentWeedsKilled = 0;
        routeMoves = 0;
        currentTotalPoints = 0;
    }
    public void AddCleanedDirt()
    {
        currentWeedsKilled++;
    }
    
    public void AddRouteMoves()
    {
        routeMoves++;
    }
    public void DeleteRouteMoves()
    {
        routeMoves--;
    } 
    public void CalculateScore()
    {
        if(currentWeedsKilled == sceneData.redWeeds)
        {
            currentTotalPoints++;
        }
        if(currentTotalPoints == 2 && routeMoves <= sceneData.maxArrows)
        {
            currentTotalPoints++;
        }
       
    }

    public void EndLevel()
    {
        CalculateScore();

        if (levelLoader != null)
        {
            levelLoader.SetScoreText(currentTotalPoints);
            UpdateHighScore();
        }
    }

    private void UpdateHighScore()
    {
        if (currentTotalPoints > sceneData.currentStatus)
        {
            sceneData.currentStatus = currentTotalPoints;
            Debug.Log("Nowy najlepszy wynik: " + currentTotalPoints);
        }
        else
        {
            Debug.Log("Aktualny najlepszy wynik: " + sceneData.currentStatus);
        }
    }
}
