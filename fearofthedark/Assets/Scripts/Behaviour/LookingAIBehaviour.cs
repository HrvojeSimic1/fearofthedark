using UnityEngine;

public class LookingAIBehaviour : MonoBehaviour
{
	private Transform target;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		var lookAt = new Vector3(target.position.x, transform.position.y, target.position.z);
		transform.LookAt(lookAt);
	}
}
