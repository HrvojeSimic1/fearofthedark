using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CopyComponents : MonoBehaviour
{
	public enum Direction
	{
		Up, Down, Left, Right, Forward, Back
	}

	public GameObject objectToCopy;
	[Space]
	public Vector3 offset;
	public Direction direction;
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
				Vector3 meshSize = meshRenderer.bounds.size;

				resetList.Add(Instantiate(objectToCopy, position, Quaternion.identity));

				ChangeAxies(ref position, ref meshSize);

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

		Draw();
	}


	private void Draw()
	{
		Vector3 drawEnd = objectToCopy.transform.position;
		Vector3 meshExtends = meshRenderer.bounds.extents;

		for (int i = 0; i < number; i++)
		{
			var lastPosition = drawEnd;
			ChangeAxies(ref drawEnd, ref meshExtends);
			Debug.DrawLine(lastPosition, drawEnd, Color.red);
			drawEnd += offset;
		}
	}

	private void ChangeAxies(ref Vector3 position, ref Vector3 meshSize)
	{
		switch (direction)
		{
			case Direction.Up:
			case Direction.Down:
				position.y += meshSize.y;
				break;
			case Direction.Left:
			case Direction.Right:
				position.x += meshSize.x;
				break;
			case Direction.Forward:
			case Direction.Back:
				position.z = meshSize.z;
				break;
		}
	}
}
