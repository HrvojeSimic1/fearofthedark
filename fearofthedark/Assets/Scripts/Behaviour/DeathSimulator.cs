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
			Time.timeScale = 0f;
		}
        if (health < 90 && health > 0)
        {
			health++;
			healthBar.SetHealth(health);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			health -= damagePerHit;
			healthBar.SetHealth(health);
		}

        else if (collision.collider.CompareTag("Untagged"))
        {
			if (health < 90 && health > 0)
			{
				health++;
				healthBar.SetHealth(health);
			}
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
