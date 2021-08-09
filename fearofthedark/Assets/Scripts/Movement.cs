using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] MovementInfo movementInfo;

	private void Update()
	{
		Move(movementInfo.Target, movementInfo.speed);
	}

	private void Move(Transform target, float speed)
	{
		transform.position = Vector3.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
	}
}
