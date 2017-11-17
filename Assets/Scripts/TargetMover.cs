using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour 
{
	
	public enum MovementDirection
	{
		Horizontal,
		Vertical
	}

	public float Speed = 1.0f;
	public MovementDirection Direction = MovementDirection.Horizontal;
	void Update()
	{
		switch (Direction) 
		{

		case MovementDirection.Horizontal:
			transform.Translate (Mathf.Sin (Time.timeSinceLevelLoad) * Vector3.right * Speed * Time.deltaTime);	
			break;

		case MovementDirection.Vertical:
			transform.Translate (Mathf.Sin (Time.timeSinceLevelLoad) * Vector3.up * Speed * Time.deltaTime);	
			break;

		default:
			break;	
		}


	}
}
