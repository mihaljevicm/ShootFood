using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("set");
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("go");
			GameManager.gm.GoldKey = true;
			Destroy (gameObject);
		}
	}
}
