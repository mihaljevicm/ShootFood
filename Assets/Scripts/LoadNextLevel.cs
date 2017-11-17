﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour 
{
	public void LoadNewLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1 );
	}
}
