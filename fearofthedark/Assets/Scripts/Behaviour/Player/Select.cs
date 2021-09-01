using UnityEngine;

public class Select : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			var ray = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(ray, out RaycastHit info))
			{
				var interactObject = info.collider.GetComponent<Interact>();
				if (interactObject != null) StartCoroutine(interactObject.PlayInteraction());
			}
		}
	}
}
