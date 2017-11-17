using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKey : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			GameManager.gm.KeySilver = true;
			Destroy (gameObject);
		}
	}
}
