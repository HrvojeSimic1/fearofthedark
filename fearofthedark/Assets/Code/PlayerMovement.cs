using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;
	[SerializeField] float mouseSensitivity;

	[SerializeField] float moveSpeed;
	[SerializeField] float jumpForce;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var transformAngles = transform.eulerAngles;
		transformAngles.y = followCamera.transform.eulerAngles.y;
		transform.eulerAngles = transformAngles;

		_rigidbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime)
			+ (transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_rigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime);
		}
	}
}
