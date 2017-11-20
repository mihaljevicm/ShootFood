using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int Score = 0;
    public Text ScoreText;

    public float Timer = 20.0f;
    public Text TimerText;

	public int EnemyKills =0;
	public Text KillScoreText;

	public int Lives = 0;
	public Text LivesText;

    public int OverAllScore = 0;

    //public int VictoryScore = 5;
    public Canvas VictoryCanvas;
    public Canvas DefeatCanvas;
    public Canvas FPSCanvas;

    public GameObject ThirdPersonCam;
    public GameObject FirstPersonCam;
    public bool cameraChange = false;

    private AudioSource _backgroundSounds;
    private AudioSource _playerAudioSource;
    public AudioClip[] Clip;
    public float CoinVolume = 0.5f;
    public float HVCoinVolume = 0.6f;

    private GameObject Player;
    private GameObject[] Enemy;
    private GameObject[] HVCoin;
    Transform playerPosition;

	public bool KeySilver=false, GoldKey=false, levelCondition=false;
	private bool stopTime = true;

    

    void Start()
    {
        ThirdPersonCam.SetActive(true);
        FirstPersonCam.SetActive(false);
        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        HVCoin = GameObject.FindGameObjectsWithTag("HVCoin");

        //if (PlayerController.pc != null)
			_playerAudioSource = Player.GetComponent<AudioSource>();
		if (_playerAudioSource == null)
			_playerAudioSource = GetComponent<AudioSource> ();

        _backgroundSounds = GetComponent<AudioSource>();
        _backgroundSounds.clip = Clip[0];
        _backgroundSounds.loop = true;
        _backgroundSounds.Play();

       
    }

    void Awake()
    {
        gm = this;

        VictoryCanvas.enabled = false;
        DefeatCanvas.enabled = false;

    }

    void Update()
    {
		if(Input.GetKey("escape"))
		{
			Application.Quit ();
		}
        if (stopTime == true)
        {
            ChangeTime(Time.deltaTime);
        }
		if (Input.GetMouseButton(1))
        {
            cameraChange = true;
        }
        
        else
        {
            cameraChange = false;
        }
        ChangeCamera(cameraChange);

        /*
        if(KeySilver || GoldKey)
        {
            if (_playerAudioSource == null)
                _playerAudioSource = GetComponent<AudioSource>();
            else
                _playerAudioSource.PlayOneShot(Clip[5], HVCoinVolume);
        }
        */

		if (KeySilver && GoldKey)
			levelCondition = true;

		Lives = Player.GetComponent<HealthManager> ().NumberOfLives;
    }


    public void PrintName()
    {
        Debug.Log(gameObject.name);
    }

    void ChangeCamera(bool camera)
    {
        if (camera)
        {
            ThirdPersonCam.gameObject.SetActive(false);
            //ThirdPersonCam.enabled = false;
            FirstPersonCam.gameObject.SetActive(true);
            //FirstPersonCam.enabled = true;
            FPSCanvas.enabled = true;
            Debug.Log("first");
        }
        else
        {
            FirstPersonCam.gameObject.SetActive(false);
            //FirstPersonCam.enabled = false;
            ThirdPersonCam.gameObject.SetActive(true);
            //ThirdPersonCam.enabled = true;
            FPSCanvas.enabled = false;
            Debug.Log("third");
        }
        Debug.Log("camera change");
        cameraChange = true;
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreText.text = "Score : " + Score.ToString();

        if (amount == 1)
        {
            PlayCoinSound();
        }

        if (amount == 5)
        {
            PlayHVCoinSound();
        }
			

    }

	public void EnemyKill(int amount)
	{
		EnemyKills += amount;
		KillScoreText.text = "Kill count:" + EnemyKills.ToString ();
	}

	public void LivesLeft(int amount)
	{
		LivesText.text = "Lives: " + amount.ToString();
	}

    public void ChangeTime(float amount)
    {
        Timer += amount;
        TimerText.text = "Timer : " + Timer.ToString();
    }

    public void PlayerFreeze()
    {

        playerPosition = Player.GetComponent<Transform>();
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<SphereCollider>().enabled = false;
        Player.GetComponent<Rigidbody>().useGravity = false;
        Player.GetComponent<Rigidbody>().Sleep();
        Player.transform.position = playerPosition.transform.position;
        if (FirstPersonCam)
            FirstPersonCam.GetComponent<Shoot>().enabled = false;
    }

    public void EnviromentFreeze()
    {
		FPSCanvas.enabled = false;
        stopTime = false;
        foreach (GameObject EnemySpawner in Enemy)
            EnemySpawner.GetComponent<EnemySpawner>().IsActive = false;
        foreach (GameObject HighValueCoinSpawn in HVCoin)
            if (HighValueCoinSpawn.GetComponent<ObjectSpawner>() != null)
                HighValueCoinSpawn.GetComponent<ObjectSpawner>().IsActive = false;
    }

    public void OnVictory()
    {
        OverAllScore = (Score * EnemyKills) / (int)Timer;
        Debug.Log("Score: " + OverAllScore);
        VictoryCanvas.enabled = true;
        _backgroundSounds.Stop();
        _backgroundSounds.clip = Clip[3];
        PlayerFreeze();
        EnviromentFreeze();
        _backgroundSounds.Play();
    }
    public void OnDefeat()
    {
        DefeatCanvas.enabled = true;
        _backgroundSounds.Stop();
        _backgroundSounds.clip = Clip[4];
        PlayerFreeze();
        EnviromentFreeze();
        Debug.Log(Clip[4].loadState);
        _backgroundSounds.Play();
    }

    public void LoadScene(int what)
    {
        //0 - This scene
        //1 - Next scene

        if (what == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (what == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayCoinSound() //Coin value 1
    {
		if (_playerAudioSource == null)
			_playerAudioSource = GetComponent<AudioSource> ();
		else
        _playerAudioSource.PlayOneShot(Clip[1], CoinVolume);
    }

    public void PlayHVCoinSound() //Coin value 5
    {
		if (_playerAudioSource == null)
			_playerAudioSource = GetComponent<AudioSource> ();
		else
        _playerAudioSource.PlayOneShot(Clip[2], HVCoinVolume);
    }
}