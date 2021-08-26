using UnityEngine;

public abstract class AnimalAI : MonoBehaviour
{
	protected int midMoveSpeed;
	protected int maxMoveSpeed;

	protected Vector3 target;
	protected bool isInColliderRange;

	protected void Start()
	{
		target = transform.position;
	}

	protected Vector3 GetRandomVector3(int setX = 7, int setY = 0, int setZ = 7)
	{
		return new Vector3(Random.Range(-setX, setX), Random.Range(-setY, setY), Random.Range(-setZ, setZ));
	}
}