using UnityEngine;

[CreateAssetMenu]
public class MovementInfo : ScriptableObject
{
	public float speed;
	public float rotationSpeed;
	public Transform Target { get; set; }

	private void OnEnable() => Target = GameObject.FindGameObjectWithTag("Player").transform;
}
