using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;

	[SerializeField] float moveSpeed;
	[SerializeField] float smoothness;
	[SerializeField] AudioSource walkSound;

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

		if(_vertical + _horizontal > 0.1f && !walkSound.isPlaying)
		{
			walkSound.Play();
		}
	}


	void FixedUpdate()
	{
		Vector3 force = ((transform.forward * _vertical * moveSpeed)
					+ (transform.right * _horizontal * moveSpeed)) * smoothness;

		_rigidbody.AddForce(force - new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z), ForceMode.VelocityChange);
	}
}
