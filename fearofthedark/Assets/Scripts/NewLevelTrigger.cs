using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelTrigger : MonoBehaviour
{
	public Vector3 collision = Vector3.zero;
	public LayerMask layer;

	public int range = 100;

	public int levelNumber;

	void Update()
	{
		if (Input.GetKey("e"))
		{
			var ray = new Ray(transform.position, transform.forward);
			if (Physics.Raycast(ray, out RaycastHit hit, range, layer))
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
