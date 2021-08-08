using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationMM : MonoBehaviour
{

    // Update is called once per frame

    public float speed=1;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
