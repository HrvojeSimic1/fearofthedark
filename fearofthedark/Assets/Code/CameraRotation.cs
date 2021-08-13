using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField] float mouseSensitivity;
	private float _horizontalMovement;
	private float _verticalMovement;
	private float _mouseX;
	private float _mouseY;

	private void Update()
	{
		_mouseX = Input.GetAxis("Mouse X");
		_mouseY = Input.GetAxis("Mouse Y");
		_horizontalMovement += _mouseX * mouseSensitivity;
		_verticalMovement -= _mouseY * mouseSensitivity;

		_verticalMovement = Mathf.Clamp(_verticalMovement, -40, 40);
	}

	void FixedUpdate()
	{
		transform.eulerAngles = new Vector3(_verticalMovement, _horizontalMovement, 0);
	}

}
