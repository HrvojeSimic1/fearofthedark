using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CopyComponents : MonoBehaviour
{
	public GameObject objectToCopy;
	[Space]
	public Vector3 offset;
	[Space]
	public int number;
	[Space]
	public MeshRenderer meshRenderer;
	public bool removeChanges;
	[Space]
	[Space]
	public bool apply;

	private List<GameObject> resetList = new List<GameObject>();

	private void Update()
	{
		if (apply)
		{
			apply = false;
			var position = objectToCopy.transform.position;
			for (int i = 0; i < number; i++)
			{
				resetList.Add(Instantiate(objectToCopy, position, Quaternion.identity));
				position.x += meshRenderer.bounds.size.x;
				position += offset;
			}
		}

		if (removeChanges)
		{
			removeChanges = false;
			for (int i = 0; i < resetList.Count; i++)
			{
				DestroyImmediate(resetList[i]);
			}
			resetList.Clear();
		}
	}
}
