using UnityEngine;

public class Follow : MonoBehaviour
{
	[SerializeField] Transform followObject;

	[SerializeField] Vector3 Offset;

	private void Update()
	{
		transform.position = followObject.position + Offset;
	}
}
