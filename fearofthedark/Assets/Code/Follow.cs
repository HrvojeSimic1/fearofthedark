using UnityEngine;

public class Follow : MonoBehaviour
{
	[SerializeField] Transform followObject;

	public float OffsetX;
	public float OffsetY;

	private void Update()
	{
		transform.position = followObject.position + Vector3.right * OffsetX + Vector3.up * OffsetY;
	}
}
