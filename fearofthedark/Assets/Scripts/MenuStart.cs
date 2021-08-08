using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas startC;
    public Canvas mainC;

    // Use this for initialization
    void Start()
    {
        startC.GetComponent<Canvas>().enabled = true;
        mainC.GetComponent<Canvas>().enabled = false;
    }


    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            startC.GetComponent<Canvas>().enabled = false;
            mainC.GetComponent<Canvas>().enabled = true;
        }
    }
}
