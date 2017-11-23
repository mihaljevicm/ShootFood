using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassCoinCondition : MonoBehaviour {

    private bool pass = false;
	void Update () 
	{
		pass = GameManager.gm.levelCondition;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		if(pass)
			GameManager.gm.OnVictory ();
		 else if(!pass)
            {
              GameManager.gm.FalsePassCondition();
             
            }
	}
}
