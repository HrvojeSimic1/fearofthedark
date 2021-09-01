using UnityEngine;

public class Select : MonoBehaviour
{
	private void Update()
	{
			Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
		if (Input.GetKeyDown(KeyCode.E))
		{
			var ray = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(ray, out RaycastHit info))
			{
				var interactObject = info.collider.GetComponent<Interact>();
				print(interactObject);
				if (interactObject != null) interactObject.PlayInteraction();
			}
		}
	}
}
