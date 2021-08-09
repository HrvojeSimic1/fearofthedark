using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField] float mouseSensitivity;
	private float horizontalMovement;
	private float verticalMovement;

	void Update()
	{
		horizontalMovement += Input.GetAxis("Mouse X") * mouseSensitivity;
		verticalMovement += -Input.GetAxis("Mouse Y") * mouseSensitivity;

		verticalMovement = Mathf.Clamp(verticalMovement,-40,40);
		transform.eulerAngles = new Vector3(verticalMovement, horizontalMovement, 0);
	}
}
