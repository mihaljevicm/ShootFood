using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	//public static PlayerController pc;

	public float Speed = 10.0f;
    public Transform FPSCamera;
    public Transform TPCamera;
    //private bool camClick;
	private int lives =0;

	private float _moveHorizontal = 0.0f;
	private float _moveVertical = 0.0f;

    [SerializeField]
    private AudioSource _audioSource;
	private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private Vector3 direction;


    void Start () 
	{
        //pc = this;
        _transform = GetComponent<Transform>();
		_rigidbody = GetComponent<Rigidbody> ();
        _audioSource = GetComponent<AudioSource>();
        //camClick = GameManager.gm.cameraChange;
    }
	

	void Update () 
	{
        CheckForInput ();

		lives = GetComponent<HealthManager>().NumberOfLives;
		GameManager.gm.LivesLeft (lives);
        if(_transform.position.y <= 0)
        {
            HealthManager _healthManager = GetComponentInParent<HealthManager>();
            _healthManager.ApplyDamage(_healthManager.Health);
        }

       
    }

	void CheckForInput ()
	{
		_moveHorizontal = Input.GetAxisRaw ("Horizontal");
		_moveVertical = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate ()
		{
            Move();
		}

	void Move()
	{

       
        direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0.0f;
        direction.Normalize();
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
