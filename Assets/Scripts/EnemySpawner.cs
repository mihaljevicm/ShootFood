﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public FollowTarget ObjectToSpawn;
	public ExtremeValues IntervalValues;
	private GameObject _player;
	public bool IsActive = true;

	
    public void SpawnEnemy()
	{
		
			GameObject objectClone = Instantiate (ObjectToSpawn.gameObject, transform.position, Quaternion.identity);
			objectClone.transform.SetParent (transform);

			_player = GameObject.FindWithTag ("Player");

			objectClone.GetComponent<FollowTarget> ().SetTarget (_player.transform);

	}
    
	public IEnumerator SpawnTimer()
	{
		while (IsActive) 
		{
			yield return new WaitForSeconds (IntervalValues.RandomValue());

			SpawnEnemy ();
		}
	}
}
