using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] Camera followCamera;

	[SerializeField] float moveSpeed;
	[SerializeField] float smoothness;
	[SerializeField] AudioSource walkSound;
	[SerializeField] GameObject gameObjectOnOff;

	private float _vertical;
	private float _horizontal;

	public static bool gameIsPaused;

	private void Start()
	{
		Time.timeScale = 1;
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (!gameIsPaused)
		{
			_vertical = Input.GetAxis("Vertical");
			_horizontal = Input.GetAxis("Horizontal");
			var transformAngles = transform.eulerAngles;
			transformAngles.y = followCamera.transform.eulerAngles.y;
			transform.eulerAngles = transformAngles;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameIsPaused = !gameIsPaused;
			PauseGame();
		}

        if (_vertical + _horizontal != 0 && !walkSound.isPlaying)
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

	void PauseGame()
	{
		if (gameIsPaused)
		{
			Time.timeScale = 0f;
			gameObjectOnOff.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			gameObjectOnOff.SetActive(false);
		}
	}

}
