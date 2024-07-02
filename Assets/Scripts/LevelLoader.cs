using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public SceneConfigsSO sceneData;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject tutorialUI;
    
    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }
    
    public void Level2()
    {
        SceneManager.LoadScene("Level_2");
    }
    
    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }
    
    public void Level4()
    {
        SceneManager.LoadScene("Level_4");
    }
    
    public void Level5()
    {
        SceneManager.LoadScene("Level_5");
    }
    
    public void Level6()
    {
        SceneManager.LoadScene("Level_6");
    }
   
    public void Level7()
    {
        SceneManager.LoadScene("Level_7");
    }
    
    public void Level8()
    {
        SceneManager.LoadScene("Level_8");
    }
    
    public void Level9()
    {
        SceneManager.LoadScene("Level_9");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    public void Tutorial()
    {
        tutorialUI.SetActive(true);
    }

    public void SettingsOut()
    {
        settingsUI.SetActive(false);
    }

    public void TutorialOut()
    {
        tutorialUI.SetActive(false);
    }
    
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    
}
