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

    [SerializeField]
    private Vector3 direction;


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
		lives = GetComponent<HealthManager>().NumberOfLives;
		GameManager.gm.LivesLeft (lives);

       
    }

	void CheckForInput ()
	{
		_moveHorizontal = Input.GetAxisRaw ("Horizontal");
		_moveVertical = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate ()
		{
        //if (camClick)
            Move();
        //else
            //TpMove();

        //direction.Normalize();
		}

	void Move()
	{

        //Vector3 movement = FPSCamera.TransformDirection(movementX + movementZ);
        direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.Normalize();
        _rigidbody.AddForce(direction * Speed); //TODO: uzimati isključivo bez y vektor
        
      
            
	}
    /*
    void TpMove() 
        {
        _directionTP = TPCamera.transform.forward;    
        _directionTP = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        _directionTP = TPCamera.transform.TransformDirection (_directionTP);
		_directionTP.Normalize ();
        _rigidbody.AddForce(_directionTP * Speed);
        }
*/
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
