using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour {

    [SerializeField]
    private List<ObjectSpawner> _spawners;
    [SerializeField]
    private List<EnemySpawner> _enemis;
	
	void Start ()
    {
        foreach (ObjectSpawner spawner in _spawners)
        {
            spawner.IsActive = false;
        }

        foreach (EnemySpawner enemy in _enemis)
        {
            enemy.IsActive = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach (ObjectSpawner spawner in _spawners)
            {
                spawner.IsActive = true;
            }

            foreach (EnemySpawner enemy in _enemis)
            {
                enemy.IsActive = true;
                enemy.StartCoroutine(enemy.GetComponent<EnemySpawner>().SpawnTimer());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (ObjectSpawner spawner in _spawners)
            {
                spawner.IsActive = false;
            }

            foreach (EnemySpawner enemy in _enemis)
            {
                enemy.IsActive = false;
                //enemy.StopCoroutine(enemy.GetComponent<EnemySpawner>().SpawnTimer());
            }
        }
    }

}
