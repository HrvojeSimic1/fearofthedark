using UnityEngine;

public class DeathSimulator : MonoBehaviour
{
	[SerializeField] int health;
	[Range(0, 100)] [SerializeField] int damagePerHit;

	[SerializeField] GameObject gameObjectOnOff;

	private void Update()
	{
		if(health <= 0)
		{
			gameObjectOnOff.SetActive(true);
		}
		print(health);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			health -= damagePerHit;
			health = Mathf.Clamp(health, 0, 100);
		}
	}

}
