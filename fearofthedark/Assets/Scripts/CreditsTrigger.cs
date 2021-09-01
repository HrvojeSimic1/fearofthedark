using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTrigger : MonoBehaviour
{

    public GameObject canvas;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Credits Trigger"))
        {
            canvas.SetActive(true);
        }
    }
}
