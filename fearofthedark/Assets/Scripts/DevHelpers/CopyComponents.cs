using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class CopyComponents : MonoBehaviour
{
	public enum Direction
	{
		Up, Down, Right, Left, Forward, Back
	}

	public Transform objectToCopyTransform;
	public GameObject originalPrefab;
	[Space]
	public Transform useAsParent;
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
			var position = objectToCopyTransform.position;
			for (int i = 0; i < number + 1; i++)
			{
				Vector3 meshSize = meshRenderer.bounds.size;

				resetList.Add(PrefabUtility.InstantiatePrefab(originalPrefab, useAsParent) as GameObject);
				resetList[i].transform.position = position;

				ChangeAxies(ref position, ref meshSize);
				position += offset;
			}
			DestroyImmediate(resetList[0]);
			resetList.RemoveAt(0);
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
		Vector3 drawEnd = objectToCopyTransform.position;
		Vector3 meshSize = meshRenderer.bounds.size;

		for (int i = 0; i < number + 1; i++)
		{
			var lastPosition = drawEnd;
			ChangeAxies(ref drawEnd, ref meshSize);
			Debug.DrawLine(lastPosition, drawEnd, Color.green);
			drawEnd += offset;
		}
	}

	private void ChangeAxies(ref Vector3 position, ref Vector3 meshSize)
	{
		switch (direction)
		{
			case Direction.Up:
				position.y += meshSize.y;
				break;
			case Direction.Down:
				position.y -= meshSize.y;
				break;
			case Direction.Right:
				position.x += meshSize.x;
				break;
			case Direction.Left:
				position.x -= meshSize.x;
				break;
			case Direction.Forward:
				position.z += meshSize.z;
				break;
			case Direction.Back:
				position.z -= meshSize.z;
				break;
		}
	}
	private Vector3 GetInputDirection()
	{
		Vector3 dir = Vector3.zero;
		switch (direction)
		{
			case Direction.Up:
				dir = Vector3.up;
				break;
			case Direction.Down:
				dir = Vector3.down;
				break;
			case Direction.Left:
				dir = Vector3.left;
				break;
			case Direction.Right:
				dir = Vector3.right;
				break;
			case Direction.Forward:
				dir = Vector3.forward;
				break;
			case Direction.Back:
				dir = Vector3.back;
				break;
		}
		return dir;
	}

	public static Vector3 MultiplayAxies(Vector3 a, Vector3 b)
	{
		return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
	}
}
