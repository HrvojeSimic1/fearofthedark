using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{

    public Vector3 collision = Vector3.zero;
    public LayerMask layer;


    public int range = 100;

    public int levelNumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, layer))
            {
                Debug.Log(hit.transform.gameObject);
                NextScene();
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(levelNumber);
    }

}
