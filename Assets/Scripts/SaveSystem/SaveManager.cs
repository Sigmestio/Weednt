using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public void SaveGame()
    {
        SaveData.Current.sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SerializationManager.Save("saveFile", SaveData.Current);
        Debug.Log("Game Saved");
    }
    
    public void SaveGameAndQuit()
    {
        SaveData.Current.sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SerializationManager.Save("saveFile", SaveData.Current);
        Debug.Log("Game Saved");
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SaveData data = (SaveData)SerializationManager.Load("saveFile");
        if (data != null)
        {
            SceneManager.LoadScene(data.sceneNumber);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.LogError("No save file found.");
        }
    }
}
