using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    
    public Canvas startC;
    public Canvas mainC;

    public AudioSource playSound;

    int phase = 0;
    void Start()
    {
        startC.GetComponent<Canvas>().enabled = true;
        mainC.GetComponent<Canvas>().enabled = false;
    }


    void Update()
    {
        if (Input.GetButton("Submit") && phase==0)
        {
            startC.GetComponent<Canvas>().enabled = false;
            mainC.GetComponent<Canvas>().enabled = true;

            playSound.Play(0);

            phase++;
        }
    }
}
