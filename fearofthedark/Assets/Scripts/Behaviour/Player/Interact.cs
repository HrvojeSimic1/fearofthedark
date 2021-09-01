using UnityEngine;

public class Interact : MonoBehaviour
{
	public GameObject interactableObject;
	[SerializeField] float seconds = 3f;

	private static float timer = 0;

	private void Update()
	{
		timer += Time.deltaTime;
		if(timer >= seconds + 0.1f)
		{
			timer = 0;
		}
	}

	public void PlayInteraction()
	{
		interactableObject.SetActive(true);
		if (timer >= seconds)
		{
			interactableObject.SetActive(false);
		}
	}
}
