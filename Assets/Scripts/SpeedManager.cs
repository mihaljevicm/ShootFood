using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {

	public float SpeedMultiplier = 2.0f;


	void OnCollisionEnter(Collision other)
	{
		//other.gameObject.GetComponent<HealthManager> ().ApplyDamage (Damage);

		PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();

		if (playerController != null) 
		{
			playerController.Speed *= SpeedMultiplier;
		}
	}
}
