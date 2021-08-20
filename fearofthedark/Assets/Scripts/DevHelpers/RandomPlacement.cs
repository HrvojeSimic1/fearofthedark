using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class RandomPlacement : MonoBehaviour
{
	public GameObject Target;
	[Space]
	public Vector3Int range;
	public int theSameValue;
	public bool useTheSameValue;
	public Vector3Int offset;
	[Space]
	[Range(0, 100)]
	public int frequency;
	[Space]
	public bool removeLastChanges;
	[Space]
	[Space]
	public bool apply;

	public List<GameObject> toSpawnObjects;

	private List<GameObject> resetList = new List<GameObject>();

	private void Update()
	{
		if (useTheSameValue)
		{
			var temp = range;
			temp.x = temp.y = temp.z = theSameValue;
			range = temp;
		}
		if (apply)
		{
			resetList.Clear();
			for (int i = 0; i < frequency; i++)
			{
				Vector3 position = Target.transform.position;
				GameObject randomElement = toSpawnObjects?.ElementAt(Random.Range(0, toSpawnObjects.Count - 1));

				if (!resetList.Contains(randomElement))
				{
					resetList.Add(Instantiate(
						randomElement,
						new Vector3(position.x + Random.Range(-range.x, range.x) + offset.x, position.y + Random.Range(-range.y, range.y) + offset.y, position.z + Random.Range(-range.z, range.z) + offset.z),
						Quaternion.identity, Target.transform));
				}
			}
			apply = false;
		}

		if (removeLastChanges)
		{
			removeLastChanges = false;
			for (int i = 0; i < resetList.Count; i++)
			{
				DestroyImmediate(resetList[i]);
			}
			resetList.Clear();
		}

		if (Target == null)
		{
			return;
		}

		DrawRGBLines();
	}

	private void DrawRGBLines()
	{
		Vector3 position = Target.transform.position;
		Vector3 offsetX = new Vector3(offset.x, 0);
		Vector3 offsetY = new Vector3(0, offset.y);
		Vector3 offsetZ = new Vector3(0, 0, offset.z);

		Debug.DrawLine(position - new Vector3(range.x, 0, 0) + offsetX, position + new Vector3(range.x, 0, 0) + offsetX, Color.red);
		Debug.DrawLine(position - new Vector3(0, range.y, 0) + offsetY, position + new Vector3(0, range.y, 0) + offsetY, Color.green);
		Debug.DrawLine(position - new Vector3(0, 0, range.z) + offsetZ, position + new Vector3(0, 0, range.z) + offsetZ, Color.blue);
	}
}
