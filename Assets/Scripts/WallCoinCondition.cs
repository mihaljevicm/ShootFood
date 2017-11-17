using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCoinCondition : MonoBehaviour {

    [SerializeField]
    private int ScoreToPass = 50;

private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            if(GameManager.gm.Score > ScoreToPass)
            {
                Debug.Log("pass");
                Destroy(gameObject);
            }
        }
    } 
}
