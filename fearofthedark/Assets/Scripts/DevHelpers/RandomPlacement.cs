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
	[Space]
	public int numberOfRandElem;
	[Space]
	public bool removeChanges;
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
			for (int i = 0; i < numberOfRandElem; i++)
			{
				Vector3 position = Target.transform.position;

				resetList.Add(Instantiate(
					toSpawnObjects?.ElementAt(Random.Range(0, toSpawnObjects.Count - 1)),
					new Vector3(position.x + Random.Range(0, range.x), position.y + Random.Range(0, range.y), position.z + Random.Range(0, range.z)),
					Quaternion.identity, Target.transform.parent));
		}
			apply = false;
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

		if (Target == null) return; 
		Debug.DrawLine(Target.transform.position - new Vector3(range.x, 0, 0), Target.transform.position + new Vector3(range.x, 0, 0), Color.red);
		Debug.DrawLine(Target.transform.position - new Vector3(0, range.y, 0), Target.transform.position + new Vector3(0, range.y, 0), Color.green);
		Debug.DrawLine(Target.transform.position - new Vector3(0, 0, range.z), Target.transform.position + new Vector3(0, 0, range.z), Color.blue);
	}
}
