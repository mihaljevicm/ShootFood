using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSilverCondition : MonoBehaviour {

	[SerializeField]
	private bool condition;

	void Update()
	{
		condition = GameManager.gm.KeySilver;
	}
	void OnCollisionEnter(Collision other)
	{
		Debug.Log ("enter");
		if (other.gameObject.tag == "Player" && condition==true) {
			Destroy (gameObject);
			Debug.Log ("destroy");
		}
	}
}
