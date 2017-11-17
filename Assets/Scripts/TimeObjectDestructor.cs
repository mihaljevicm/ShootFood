using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectDestructor : MonoBehaviour
{
	public float Timer = 1.0f;

	void Awake()
	{
		
		Invoke ("DestroyNow", Timer);
	}

	private void DestroyNow()
	{
		Destroy(gameObject);
	}

}
