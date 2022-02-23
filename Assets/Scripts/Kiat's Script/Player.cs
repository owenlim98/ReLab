using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public SpriteRenderer playerRenderer;
    public Animator animator;
    private Transform playerScale;
    public GameObject marker;

    public Button Checkpoint;

    public AudioSource audioSource;
    public MusicManager BGMControl;
    public AudioClip soundClip, baka;
    public static string colourStatus;

    public static float timeCapture = 0.0f;
    public static Vector3 spawnPos = new Vector3( 0,0,0);

    public static bool dead;
    public bool Debugging;
    public bool testPlay;
    private string otherColour;

    //private void Awake()
    //{
    //    BGMControl.Switches[0] = true;
    //}

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>(); //For movement
        playerRenderer = GetComponent<SpriteRenderer>();  //For Colour Changing
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  //For Sound Effects
        playerScale = GetComponent<Transform>();    //For size Checking
        Checkpoint.onClick.AddListener(capture);

        var boxCollider = GetComponent<BoxCollider>();  //For Collision Detection
        boxCollider.isTrigger = true;   //Prevent physical collision

        dead = false;
        
        SimpleSpawn(spawnPos, timeCapture);
        Time.timeScale = 1;

        if(colourStatus == null)
        {
            colourStatus = "Blue";
        }
    }
	
	// Update is called once per frame
	void Update () {
        rb.transform.Translate(speed * Time.deltaTime, 0, 0); //Move the player towards the rights
        audioSource.mute = SFXToggle.muted;
        if (Input.anyKeyDown && Debugging == true)   //For Mapping
        {
            Instantiate(marker, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if(GameManager.paused == true)
        {
            Time.timeScale = 0f;
        }
	}

    

    private void OnTriggerEnter(Collider other)
    {
        if (testPlay == true)
        {
            audioSource.PlayOneShot(soundClip);
            Debug.Log("Sounded");
            return;
        }

        if (other.gameObject.name == "EndZone(Clone)" || other.gameObject.name == "EndZone")       //Checks if the player have reached the end
        {
            Debug.Log("Ended");
            transform.DetachChildren();
            ScoreHandler.StageStatus = "Clear";
            return;
        }

        if (playerScale.transform.localScale.y == other.gameObject.transform.localScale.y)   //Checks if size matches
        {
            otherColour = other.gameObject.GetComponentInParent<Obstacles>().lazerColour;

            if (colourStatus == otherColour)  //Checks if Colour Match
            {
                audioSource.PlayOneShot(soundClip);
                Debug.Log("Sounded");
                ScoreHandler.seeableScore += 20;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerScale.transform.localScale.y == other.gameObject.transform.localScale.y)   //Checks if size matches
        {
            if (colourStatus == otherColour)  //Checks if Colour Match
            {
                //Goes through
            }
            else if (testPlay != true)
            {
                if (audioSource.isPlaying != true)
                {
                    BGMControl.BGMSource.Play();
                }
                Respawn(spawnPos, timeCapture);
            }
        }
        else if (testPlay != true)
        {
            if (audioSource.isPlaying != true)
            {
                BGMControl.BGMSource.Play();
            }
            Respawn(spawnPos, timeCapture);
        }
    }

    public void capture()       //Bookmark
    {
        timeCapture = BGMControl.BGMSource.time;
        spawnPos = transform.localPosition;
    }

    private void Respawn(Vector3 spawn, float songTime)
    {
        transform.position = spawn;
        BGMControl.BGMSource.time = songTime;
        dead = true;
        ScoreHandler.RespawnedData += 10;
        ScoreHandler.seeableScore = 0;
        audioSource.PlayOneShot(baka);
    }

    private void SimpleSpawn(Vector3 spawn, float songTime)
    {
        transform.position = spawn;
        BGMControl.BGMSource.time = songTime;
    }
}
