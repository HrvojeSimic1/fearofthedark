using UnityEngine;

public class ParentComponent : MonoBehaviour
{
	public Transform Target { get; private set; }

	private void Start()
	{
		Target = transform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Target = other.transform;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Target = transform;
		}
	}

}
