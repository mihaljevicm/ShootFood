using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour 
{
	public GameObject ObjectToSpawn;
	public float MinSpawnInterval = 1.0f;
	public float MaxSpawnInterval = 5.0f;
    public bool IsActive = true;


	[SerializeField]
	private float _timer = 0.0f;
	[SerializeField]
	private float _random = 0.0f;

	void Awake()
	{
		_random = Random.Range (MinSpawnInterval, MaxSpawnInterval);
	}
	void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= _random && IsActive == true)
		{
			GameObject objectClone = Instantiate (ObjectToSpawn, transform.position, Quaternion.identity);
			objectClone.transform.SetParent (transform);

			_timer = 0.0f;
			_random = Random.Range (MinSpawnInterval, MaxSpawnInterval);
		}
	}
}
