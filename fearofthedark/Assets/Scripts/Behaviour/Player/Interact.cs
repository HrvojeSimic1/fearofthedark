using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
	public GameObject interactableObject;
	[SerializeField] float seconds = 1f;


	public IEnumerator PlayInteraction()
	{
		interactableObject.SetActive(true);
		yield return new WaitForSeconds(seconds);
		interactableObject.SetActive(false);
	}
}
