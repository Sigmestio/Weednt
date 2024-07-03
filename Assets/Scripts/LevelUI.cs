using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public Button restartButton;
    [SerializeField] private GameObject info;

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); 
    }

    public void ShowInfo()
    {
        info.SetActive(true);
    }

    public void InfoOut()
    {
        info.SetActive(false);
    }
    
    //public void SaveAndLeave()

}
