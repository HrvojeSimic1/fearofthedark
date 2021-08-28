using UnityEngine;

public class DeathSimulator : MonoBehaviour
{
	[SerializeField] [Range(0, 100)] int health;
	[SerializeField] [Range(0, 100)] int damagePerHit;
	[SerializeField] HealthBar healthBar;
	[Space]
	[SerializeField] GameObject gameObjectOnOff;

	private void Start()
	{
		healthBar.SetMaxHealth(health);
	}

	private void Update()
	{
		if (health <= 0)
		{
			gameObjectOnOff.SetActive(true);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			health -= damagePerHit;
			print(health);
			healthBar.SetHealth(health);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Dark"))
		{
			health -= damagePerHit;
			healthBar.SetHealth(health);
		}
	}
}
