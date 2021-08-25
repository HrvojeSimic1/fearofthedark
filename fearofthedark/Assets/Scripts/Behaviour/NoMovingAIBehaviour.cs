using UnityEngine;

public class NoMovingAIBehaviour : MonoBehaviour
{
	private Transform target;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		target.position = new Vector3(target.position.x, transform.position.y, target.position.z);
		transform.LookAt(target);
	}
}
