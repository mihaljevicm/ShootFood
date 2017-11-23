using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class States 
{
	[Header("Read-only")]
	[SerializeField]
	public int _armor = 0;
	[SerializeField]
	public int _health = 0;

	#region Properties
	public int Armor
	{
		get
		{
			return _armor;
		}
	}


	public int Health
	{
		get
		{
			return _health;
		}
	}
	#endregion

	public States()
	{
		_armor = 10;
		_health = 10;
	}

	public States(int armor, int health)
	{
		_armor = armor;
		_health = health;
	}

	public void Damage(int amount)
	{

		if (amount <= 0) 
		{
			Debug.Log ("Damage can't be less than zero");
			return;
		}

		_armor -= amount;
		if (_armor < 0) 
		{
			_health -= _armor;
			_armor = 0;

			if (_health <= 0)
				Debug.Log ("Game over");
		}
	}
}
