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
    }

    public void doExitGame()
    {
        Application.Quit();
    }
    
}
