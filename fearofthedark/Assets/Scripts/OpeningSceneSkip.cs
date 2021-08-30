using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpeningSceneSkip : MonoBehaviour
{
    public int levelNumber=3;
    public void NextScene()
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            NextScene();
        }
    }
}
