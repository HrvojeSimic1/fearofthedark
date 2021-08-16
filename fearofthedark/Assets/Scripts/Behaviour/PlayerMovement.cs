using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;

	[SerializeField] float moveSpeed;
	[SerializeField] float smoothness;

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
		Vector3 force = ((transform.forward * _vertical * moveSpeed * Time.deltaTime)
					+ (transform.right * _horizontal * moveSpeed * Time.deltaTime)) * smoothness;

		if (Physics.Raycast(new Ray(transform.position, Vector3.down), 1f))
		{
			_rigidbody.AddForce(force - _rigidbody.velocity, ForceMode.VelocityChange);
		}
	}
}
