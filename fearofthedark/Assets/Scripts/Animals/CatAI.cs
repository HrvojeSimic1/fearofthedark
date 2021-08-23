using UnityEngine;

public class CatAI : AnimalAI
{
	private new void Start()
	{
		base.Start();
	}

	private void FixedUpdate()
	{
		int currentSpeed = isInColliderRange ? maxMoveSpeed : midMoveSpeed;

		Move(currentSpeed);

		if (transform.position == target)
		{
			target += GetRandomVector3();
			print(target);	
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

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Enemy"))
		{
			isInColliderRange = false;
		}
	}
}
