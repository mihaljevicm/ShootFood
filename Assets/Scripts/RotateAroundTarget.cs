using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour 
{
	public float Speed = 10;
	public Vector3 Axis;
	public Transform Target;


	void Start () {
		
	}
	

	void Update () 
	{
		transform.RotateAround (Target.position, Axis, Speed * Time.deltaTime);
	}
}
