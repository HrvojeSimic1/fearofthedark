using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;

	[SerializeField] float moveSpeed;

	private float _vertical;
	private float _horizontal;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		_vertical = Input.GetAxis("Vertical");
		_horizontal = Input.GetAxis("Horizontal");
		var transformAngles = transform.eulerAngles;
		transformAngles.y = followCamera.transform.eulerAngles.y;
		transform.eulerAngles = transformAngles;
	}

	void FixedUpdate()
	{
		_rigidbody.AddForce((transform.forward * _vertical * moveSpeed * Time.deltaTime)
			+ (transform.right * _horizontal * moveSpeed * Time.deltaTime), ForceMode.VelocityChange);
	}
}
