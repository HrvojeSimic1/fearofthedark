using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{

    public Scene nextLevel;
    public void NextScene()
    {
        SceneManager.LoadScene("TestingGrounds");
    }


    
}
