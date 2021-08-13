using UnityEngine;

public abstract class AIComponents : MonoBehaviour {
	
	public float speed;
	public Transform target;
	[HideInInspector] public new Rigidbody rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	public virtual void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

}
