using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExtremeValues
{
	public float MinValue;
	public float MaxValue;

	public float RandomValue()
	{
		return Random.Range (MinValue, MaxValue);
	}
}