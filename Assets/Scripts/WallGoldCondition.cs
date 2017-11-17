using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGoldCondition : MonoBehaviour 
{
	[SerializeField]
	private bool condition;

	void Update()
	{
		condition = GameManager.gm.GoldKey;
	}
	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.tag == "Player") {
			Debug.Log ("duduuu");
			if (condition)
				Destroy (gameObject);
		}
	}

}
