using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public TMP_Text highScore1Text;
    public SceneConfigsSO sceneData;
    
    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
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
    public void SetScoreText(int score)
    {
        highScore1Text.text = "Score: " + score;
    }
    
}
