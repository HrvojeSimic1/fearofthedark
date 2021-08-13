using UnityEngine;

public class SimpleAIBehaviour : AIComponents
{
	[SerializeField] bool followTarget;

	public override void Start()
	{
		if (target == null)
		{
			base.Start();
		}
	}

	private void FixedUpdate()
	{
		if (followTarget)
		{
			Move();
			Rotate();
		}
	}

	private void Rotate()
	{
		transform.LookAt(target);
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
