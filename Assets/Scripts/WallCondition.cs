using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCondition : MonoBehaviour {

    public enum condition
    {
        Coin,
        Gold,
        Silver

    }

    public condition _condition = condition.Coin;

    [SerializeField]
    [Header("For coin condition only")]
    [Range(0, 1000)]
    private int _coinsToCollect = 300;
    
    

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (_condition)
            {
                case condition.Coin:
                    if (GameManager.gm.Score > _coinsToCollect)
                    {
                        Destroy(gameObject);
                    }
                    break;
                case condition.Gold:
                    if (GameManager.gm.GoldKey)
                        Destroy(gameObject);
                    break;
                case condition.Silver:
                    if (GameManager.gm.KeySilver)
                        Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
