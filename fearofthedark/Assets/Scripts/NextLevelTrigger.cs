using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger: MonoBehaviour
{
	public Vector3 collision = Vector3.zero;
	public LayerMask levelTriggerLayer;

	public int range = 100;
	public int levelNumber;


	void Update()
	{
		if (Input.GetKey("e"))
		{
			var ray = new Ray(transform.position, transform.forward);
			if (Physics.Raycast(ray, out RaycastHit hit, range, levelTriggerLayer))
			{
				NextScene();
			}

			
		}
	}

	public void NextScene()
	{
		SceneManager.LoadScene(levelNumber);
	}

}
