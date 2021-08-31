using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{

    public int levelNumber;
    public void NextScene()
    {
        SceneManager.LoadScene(levelNumber);
        Time.timeScale = 1;
    }

    public void doExitGame()
    {
        Application.Quit();
    }
    
}
