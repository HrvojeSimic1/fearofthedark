using UnityEngine;

public class MovingAIBehaviour : MonoBehaviour
{
	[SerializeField] float speed = 2f;
	[SerializeField] float distance = 10f;

	private Transform player;
	private Vector3 targetPosition;
	private Vector3 origionalPosition;

	private void Start()
	{
		targetPosition = transform.position;
		origionalPosition = targetPosition;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		if((origionalPosition - player.position).sqrMagnitude <= distance * distance)
		{
			targetPosition = player.position;
		}
		else
		{
			targetPosition = origionalPosition;
		}
	}

	private void FixedUpdate()
	{
		if (transform.position != targetPosition)
		{
			Move();
			Rotate();
		}
	}

	private void Rotate()
	{
		Vector3 targetPostition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
		transform.LookAt(targetPostition);
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	}
}
