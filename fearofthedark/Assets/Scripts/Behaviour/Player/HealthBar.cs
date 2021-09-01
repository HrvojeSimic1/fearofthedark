using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public AudioSource noise;

	float opacity;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		//fill.color = gradient.Evaluate(1f);

		opacity = 1 - health / 100;
		fill.color = new Color(1,1,1, opacity);
	}

    public void SetHealth(int health)
	{
		slider.value = health;

		opacity = 1 - slider.value / 100;
		//Debug.Log(health);
		//Debug.Log(opacity);
		fill.color = new Color(1, 1, 1, opacity);

		noise.volume = opacity;

		//fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
