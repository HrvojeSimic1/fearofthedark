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
		Vector3 force = ((transform.forward * _vertical * moveSpeed)
					+ (transform.right * _horizontal * moveSpeed)) * smoothness;

		_rigidbody.AddForce(force - new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z), ForceMode.VelocityChange);
	}
}
