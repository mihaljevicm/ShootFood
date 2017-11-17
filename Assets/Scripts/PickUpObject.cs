using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpObject : MonoBehaviour
{

	public int Value = 1;
    //private AudioSource clip;

    void Start()
    {
        //clip = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider other)
	{
        if (other.tag == "Player" || other.tag=="Projectile")
        {
            Debug.Log("Coin picked up: " + Value);

			GameManager.gm.AddScore (Value);

			//PlayerController.pc.PlayCoinSound ();
           
            Destroy (gameObject);
		}
	}


}
