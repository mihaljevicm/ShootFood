using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChildPlayer : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
        transform.position = Player.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Player.position;
    }
}
