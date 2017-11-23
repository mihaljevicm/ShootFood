using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySerializer
{
	public static void SaveStats(States stats)
	{
		string path = Application.persistentDataPath + "/PlayerStats.dat";

		FileStream file = File.Create (path);
		BinaryFormatter bf = new BinaryFormatter ();

		bf.Serialize (file, stats);
		file.Close ();

		Debug.Log ("BinarySerializer: " + path);
	}

	public static States LoadStats()
	{
		string path = Application.persistentDataPath + "/Playerstats.dat";

		if (File.Exists (path)) 
		{
			FileStream file = File.Open (path, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter ();

			States stats = (States)bf.Deserialize (file);
			file.Close ();

			Debug.Log ("BinarySerializer: - Load - " + path);

			return stats;
		}

		Debug.LogWarning ("No data file: " + path);
		return null;
	}
}
