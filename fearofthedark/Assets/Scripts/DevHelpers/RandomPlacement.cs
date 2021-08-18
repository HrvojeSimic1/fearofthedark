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
	public bool Apply = false;
	public List<GameObject> toSpawnObjects;

	private void Update()
	{
		if (useTheSameValue)
		{
			var temp = range;
			temp.x = temp.y = temp.z = theSameValue;
			range = temp;
		}
		if (Apply)
		{
			for (int i = 0; i < toSpawnObjects.Count; i++)
			{
				Vector3 position = Target.transform.position;

				Instantiate(
					toSpawnObjects?.ElementAt(Random.Range(0, toSpawnObjects.Count - 1)),
					new Vector3(position.x + Random.Range(0, range.x), position.y + Random.Range(0, range.y), position.z + Random.Range(0, range.z)),
					Quaternion.identity, Target.transform.parent);
		}
			Apply = false;
		}

		if (Target == null) return; 
		Debug.DrawLine(Target.transform.position - new Vector3(range.x, 0, 0), Target.transform.position + new Vector3(range.x, 0, 0), Color.red);
		Debug.DrawLine(Target.transform.position - new Vector3(0, range.y, 0), Target.transform.position + new Vector3(0, range.y, 0), Color.green);
		Debug.DrawLine(Target.transform.position - new Vector3(0, 0, range.z), Target.transform.position + new Vector3(0, 0, range.z), Color.blue);
	}
}
