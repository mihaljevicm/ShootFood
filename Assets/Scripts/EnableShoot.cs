using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShoot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            GameManager.gm.canChange = true;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(GameManager.gm.Clip[6]);
            Destroy(gameObject);
        }
    }

}
