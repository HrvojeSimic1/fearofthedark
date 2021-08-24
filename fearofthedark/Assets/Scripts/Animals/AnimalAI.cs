using UnityEngine;

public abstract class AnimalAI : MonoBehaviour
{
	public int midMoveSpeed;
	public int maxMoveSpeed;
	public AudioClip animalSound;
	public AnimationClip idleAnimation;
	public AnimationClip[] movementAnimations;

	protected new Collider collider;
	protected Vector3 target;
	protected bool isInColliderRange;

	protected void Start()
	{
		collider = GetComponent<Collider>();
		target = transform.position;
	}

	protected Vector3 GetRandomVector3(int setX = 20, int setY = 0, int setZ = 20)
	{
		return new Vector3(Random.Range(-setX, setX), Random.Range(-setY, setY), Random.Range(-setZ, setZ));
	}
}