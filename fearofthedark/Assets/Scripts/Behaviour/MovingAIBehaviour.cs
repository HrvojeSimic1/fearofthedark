using UnityEngine;

public class MovingAIBehaviour : MonoBehaviour
{
	[SerializeField] ParentComponent parentComponent;
	[SerializeField] float speed;
	private Transform target;

	private void Update()
	{
		target = parentComponent.Target;
	}

	private void FixedUpdate()
	{
		if (transform.position != target.position)
		{
			Move();
			Rotate();
		}
	}

	private void Rotate()
	{
		Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, target.position.z);
		transform.LookAt(targetPostition);
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
