using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public int ScoreValue =1;
	public float TimeValue = 1.0f;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Projectile") 
		{
			//Update Score,time

			Debug.Log (ScoreValue + " " + TimeValue);

			GameManager.gm.ChangeTime (TimeValue);
			GameManager.gm.AddScore (ScoreValue);

			Destroy (gameObject);
		}
	}
}
