using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public enum OnAllLivesGone
	{
		RestartScene,
		DestroyObject
	}
	public float Health = 10.0f;
	public int NumberOfLives = 3;
	public OnAllLivesGone OnDeath=OnAllLivesGone.DestroyObject;
	public Vector3 StartingPosition = Vector3.zero;
   
    void Start ()
	{
		StartingPosition = transform.position;
    }
		

	void Update () 
	{
		
	}

	public void ApplyDamage(float amount)
	{
		Health -= amount;      //health = health - amount --> health -= amount
        if (Health <= 0.0f)             //Ako je health jednak ili manji od nule igrač će izgubiti život
        {
            NumberOfLives -= 1;

            if (NumberOfLives > 0)     //Ako je broj života veći od nule , igrač će nakon izgubljenog života imati ponovo 10 healtha i resetirat će se na staru poziciju
            {
                Health = 15.0f;

                transform.position = StartingPosition;
            }
            else                                         //Ako je broj života manji od 0 level će se resetirati i varijable će se vratiti na početno stanje
            {
                if (OnDeath == OnAllLivesGone.RestartScene)
                {
                    GameManager.gm.OnDefeat();

                }


                if (OnDeath == OnAllLivesGone.DestroyObject)
                    Destroy(gameObject);
            }
        }
    }

	public void ApplyHeal(float amount)
	{
		Health += amount;
        AudioSource _audioSource = GetComponentInParent<AudioSource>();
        AudioClip _clip = _audioSource.clip;
        _audioSource.PlayOneShot(_clip);
	}

	public void AddLives(int amount)
	{
		NumberOfLives += amount;
	}

	public void RemoveLives (int amount)
	{
		NumberOfLives -= amount;
		//GameManager.gm.LivesLeft (NumberOfLives);
	}
}
