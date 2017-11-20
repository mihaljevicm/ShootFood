using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour {

    public enum KeyCtrl
    {
        GoldKey,
        SilverKey
    }
    public KeyCtrl PickedKey = KeyCtrl.GoldKey;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("set");
        if (other.gameObject.tag == "Player")
        {
            switch (PickedKey)
            {
                case KeyCtrl.GoldKey:
                    {
                    GameManager.gm.GoldKey = true;
                    break;
                    }
                case KeyCtrl.SilverKey:
                    {
                        GameManager.gm.KeySilver = true;
                        break;
                    }
            }

            //Debug.Log("go");
            //GameManager.gm.GoldKey = true;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(GameManager.gm.Clip[5]);
            Destroy(gameObject);
        }
    }
}
