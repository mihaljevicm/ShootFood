using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public static PlayerController pc;

	public float Speed = 10.0f;
    public Transform FPSCamera;
    public Transform TPCamera;
    private bool camClick;
	private int lives =0;

	private float _moveHorizontal = 0.0f;
	private float _moveVertical = 0.0f;

	private Rigidbody _rigidbody;

    Vector3 direction;
    



    void Start () 
	{
        pc = this;
		_rigidbody = GetComponent<Rigidbody> ();
        camClick = GameManager.gm.cameraChange;
    }
	

	void Update () 
	{
       // transform.parent.position = transform.position;
        CheckForInput ();
        //Vector3 movement = FPSCamera.TransformDirection(_moveHorizontal, 0, _moveVertical);
		lives=GetComponent<HealthManager>().NumberOfLives;
		GameManager.gm.LivesLeft (lives);

		
	}

	void CheckForInput ()
	{
		_moveHorizontal = Input.GetAxisRaw ("Horizontal");
		_moveVertical = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate ()
		{
        if (camClick)
            FpsMove();
        else
            TpMove();

        direction.Normalize();
		}

	void FpsMove()
	{

        //Vector3 movement = FPSCamera.TransformDirection(movementX + movementZ);
        direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
		direction = FPSCamera.transform.TransformDirection(direction);   
        _rigidbody.AddForce(direction * Speed);
      
            
	}

    void TpMove() 
        {     
        direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        direction = TPCamera.transform.TransformDirection (direction);
		direction.Normalize ();
        _rigidbody.AddForce(direction * Speed);
        }

    /*void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Coin") 
		{
            GameManager.gm.PlayCoinSound();
		}
        
		if (other.tag == "HVCoin") 
		{
            GameManager.gm.PlayHVCoinSound();
		}

	}*/
}
