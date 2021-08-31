using UnityEngine;

public class VignetteHealth : MonoBehaviour
{
	public int opacity;

	public void SetMaxHealth(int health)
	{
		opacity = health;
	}

	public void SetHealth(int health)
	{
		opacity = health;
	}

}
