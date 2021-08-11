using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;

	[SerializeField] float moveSpeed;
	[SerializeField] float jumpForce;

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
	}

	void FixedUpdate()
	{
		var transformAngles = transform.eulerAngles;
		transformAngles.y = followCamera.transform.eulerAngles.y;
		transform.eulerAngles = transformAngles;

		_rigidbody.MovePosition(transform.position + (transform.forward * _vertical * moveSpeed * Time.deltaTime)
			+ (transform.right * _horizontal * moveSpeed * Time.deltaTime));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_rigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime);
		}
	}
}
