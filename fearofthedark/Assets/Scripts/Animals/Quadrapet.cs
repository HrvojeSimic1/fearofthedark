using UnityEngine;

public class Quadrapet : AnimalAI
{
	[SerializeField] Transform endPoint;

	private new void Start()
	{
		base.Start();
		midMoveSpeed = 5;
		maxMoveSpeed = 10;
	}

	private void Update()
	{
		if (Physics.Raycast(new Ray(transform.position, endPoint.position - transform.position), out RaycastHit info) == false
			|| Physics.Raycast(new Ray(transform.position, transform.forward), 4f))
		{
			target.x *= -1;
			target.z *= -1;
			target -= GetRandomVector3();
		}

		if (movementAnim == null) return;
		
		if (isInColliderRange)
		{

			movementAnim.Play(0);
		}

		movementAnim.Play(1);
	}

	private void FixedUpdate()
	{
		int currentSpeed = isInColliderRange ? maxMoveSpeed : midMoveSpeed;

		Move(currentSpeed);

		if (transform.position == target)
		{
			target += GetRandomVector3();
		}
	}

	private void Move(int speed)
	{
		target.y = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

		Vector3 targetPostition = new Vector3(target.x, transform.position.y, target.z);
		transform.LookAt(targetPostition);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Enemy"))
		{
			isInColliderRange = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (animalSound == null)
		{
			return;
		}

		if (other.CompareTag("Player") || other.CompareTag("Enemy"))
		{
			animalSound.Play(0);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Enemy"))
		{
			isInColliderRange = false;
		}
	}
}
