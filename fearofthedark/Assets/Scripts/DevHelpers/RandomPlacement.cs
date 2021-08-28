using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class RandomPlacement : MonoBehaviour
{
	#region Display
	[System.Serializable]
	public struct Vector3Lock
	{
		public bool x, y, z;
	}
	[Space]
	public GameObject Target;
	public bool useTargetAsParent;

	[Header("Positioning")]
	public Vector3Int range;
	public int theSameValue;
	public bool useTheSameValue;

	[Header("Fine-Tuning")]
	public Vector3Int offset;
	[Space]
	[Tooltip("The min distance between spawned objects")]
	public int minDistance;
	[Space]
	public Vector3Lock lockRandomRotation;

	[Header("Number of Iterations")]
	[Range(0, 100)]
	public int frequency;
	[Space]
	public bool removeLastChanges;
	[Space]
	[Space]
	public bool apply;
	[Space]
	[Space]
	public List<GameObject> toSpawnObjects;
	#endregion


	private List<List<GameObject>> resetList = new List<List<GameObject>>();

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
			apply = false;
			var tempStore = new List<GameObject>();
			for (int i = 0; i < frequency; i++)
			{
				Vector3 position = Target.transform.position;
				GameObject randomElement = toSpawnObjects?.ElementAt(Random.Range(0, toSpawnObjects.Count));

				tempStore.Add(PrefabUtility.InstantiatePrefab(randomElement, Target.transform) as GameObject);

				tempStore[i].transform.position = new Vector3(
					position.x + Random.Range(-range.x, range.x) + offset.x,
					position.y + Random.Range(-range.y, range.y) + offset.y,
					position.z + Random.Range(-range.z, range.z) + offset.z);

				tempStore[i].transform.rotation = QuaternionRandomRotation(lockRandomRotation.x, lockRandomRotation.y, lockRandomRotation.z);

			}
			for (int i = 0; i < tempStore.Count; i++)
			{
				Vector3 firstPosition = tempStore[i].transform.position;
				for (int j = i; j < tempStore.Count; j++)
				{
					Vector3 secondPosition = tempStore[j].transform.position;
					if (Vector3.Distance(firstPosition, secondPosition) <= minDistance)
					{
						var directionNorm = (secondPosition - firstPosition).normalized;
						secondPosition = firstPosition + directionNorm * minDistance;
						tempStore[j].transform.position = secondPosition;
					}
				}
			}
			resetList.Add(tempStore);
		}

		if (removeLastChanges)
		{
			removeLastChanges = false;
			for (int i = 0; i < resetList[resetList.Count - 1].Count; i++)
			{
				DestroyImmediate(resetList[resetList.Count - 1][i]);
			}
			resetList.RemoveAt(resetList.Count - 1);
		}

		if (Target == null)
		{
			return;
		}

		DrawRGBLines();
	}

	private Quaternion QuaternionRandomRotation(bool freezeX, bool freezeY, bool freezeZ)
	{
		Quaternion quaternion = Random.rotation;
		var copy = quaternion.eulerAngles;
		if (freezeX)
		{
			copy.x = 0;
		}

		if (freezeY)
		{
			copy.y = 0;
		}

		if (freezeZ)
		{
			copy.z = 0;
		}

		quaternion.eulerAngles = copy;
		return quaternion;
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

		Debug.DrawLine(position, position + Vector3.one * minDistance, Color.yellow);

	}
}
