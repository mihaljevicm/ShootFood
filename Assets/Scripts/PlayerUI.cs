using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public HealthManager Player;
	public Slider HealthSlider;

	void Update()
	{
		HealthSlider.value = Player.Health;
	}
}
