using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealManager : MonoBehaviour 
{
	public float Heal = 5.0f;
  
   
    void OnCollisionEnter(Collision other)
	{

		HealthManager healthManager = other.gameObject.GetComponent<HealthManager> ();

		if (healthManager != null && other.gameObject.tag == "Player") 

		{
				healthManager.ApplyHeal (Heal);
				Destroy (gameObject);

		}
	}

}

