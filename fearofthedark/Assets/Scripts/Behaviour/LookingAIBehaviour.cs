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
		transform.LookAt(target);
	}
}
