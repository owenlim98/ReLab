using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Player player;
    public Button sizeChangerM, sizeChangerP, redButton, blueButton, greenButton, pause, resume, options, quit, continues, backToPause, restartButton;
    public GameObject pauseMenu, respawnScreen, returnPosition, PauseButtons, OptionButtons, resumeTimer, timerObj;
    public Text countdown;
    public float respawnTimer;
    public ScoreHandler endscreen;

    public Vector3[] sizes;

    private int placement; //Starting Size
    public static bool paused;
    private float storeTimer;
    private float count;

    public Sprite[] playerSprites;
    public RuntimeAnimatorController[] controller;

    // Use this for initialization
    void Start () {
        redButton.onClick.AddListener(ChangeRed);
        blueButton.onClick.AddListener(ChangeBlue);
        greenButton.onClick.AddListener(ChangeGreen);
        sizeChangerM.onClick.AddListener(sizeChangeM);
        sizeChangerP.onClick.AddListener(sizeChangeP);
        pause.onClick.AddListener(Pause);
        resume.onClick.AddListener(unpause);
        options.onClick.AddListener(ToOption);
        quit.onClick.AddListener(BackToSelection);
        continues.onClick.AddListener(Continue);
        backToPause.onClick.AddListener(backtoPause);
        restartButton.onClick.AddListener(reStart);

        endscreen = GetComponent<ScoreHandler>();

        if(ScoreHandler.StageStatus == "Start")
        {
            endscreen.EndScreen.transform.position = returnPosition.transform.position;
            ScoreHandler.RespawnedData = 0f;
        }
        

        placement = 0;
        storeTimer = respawnTimer;

        if (BackButtons.previousScene == "GamePlay")
        {
            paused = false ;
            Pause();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(paused);
        if(Player.dead == true)
        {
            Time.timeScale = 0f;
            respawnScreen.SetActive(true);
            respawnTimer -= Time.fixedDeltaTime;
            count = Mathf.Round(respawnTimer);
            countdown.text = count.ToString();

            if(count <= 0)
            {
                Time.timeScale = 1f;
                respawnScreen.SetActive(false);
                Player.dead = false;
                respawnTimer = storeTimer;
                return;
            }
        }

        if(paused == true)
        {
            pause.gameObject.SetActive(!paused);
        }

        else
        {
            pause.gameObject.SetActive(!paused);
        }
	}

    public void ChangeRed()
    {
        player.playerRenderer.sprite = playerSprites[0];
        player.animator.runtimeAnimatorController = controller[0];
        Player.colourStatus = "Red";
    }
    public void ChangeBlue()
    {
        player.playerRenderer.sprite = playerSprites[1];
        player.animator.runtimeAnimatorController = controller[1];
        Player.colourStatus = "Blue";
    }
    public void ChangeGreen()
    {
        player.playerRenderer.sprite = playerSprites[2];
        player.animator.runtimeAnimatorController = controller[2];
        Player.colourStatus = "Green";
    }

    public void sizeChangeM()
    {
        //int i = placement % sizes.Length;
        placement -= 1;

        if(placement < 0 )
        {
            placement = 0;
        }
        player.transform.localScale = sizes[placement];
    }

    public void sizeChangeP()
    {
        //int i = placement % sizes.Length;
        placement += 1;
        if (placement > sizes.Length -1)
        {
            placement = sizes.Length - 1;
        }
        player.transform.localScale = sizes[placement];
    }

    private void Pause()
    {
        if(paused == false)
        {
            paused = !paused;
            Time.timeScale = 0f;
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            //pause.gameObject.SetActive(!pause.gameObject.activeInHierarchy);
            return;
        }

        if (paused == true)
        {
            paused = !paused;
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            //pause.gameObject.SetActive(!pause.gameObject.activeInHierarchy);
            //resumeTimer.gameObject.SetActive(!resumeTimer.gameObject.activeInHierarchy);
            Time.timeScale = 1f;
            return;
        }
    }

    private void unpause()
    {
        if(paused == true)
        {
            //paused = !paused;
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            //pause.gameObject.SetActive(!pause.gameObject.activeInHierarchy);
            resumeTimer.gameObject.SetActive(!resumeTimer.gameObject.activeInHierarchy);
            timerObj.GetComponent<Image>().raycastTarget = true;
            Time.timeScale = 1f;
        }
    }
    
    private void ToOption()
    {
        PauseButtons.SetActive(!PauseButtons.activeInHierarchy);
        OptionButtons.SetActive(!OptionButtons.activeInHierarchy);
    }

    private void backtoPause()
    {
        PauseButtons.SetActive(!PauseButtons.activeInHierarchy);
        OptionButtons.SetActive(!OptionButtons.activeInHierarchy);
    }

    private void BackToSelection()
    {
        SceneManager.LoadScene("LevelSelect");
        LevelNavigationButton.stageNum = 0;
    }

    private void Continue()
    {
        SceneManager.LoadScene("LevelSelect");
        ScoreHandler.StageStatus = "Start";
        LevelNavigationButton.stageNum = 0;
        ScoreHandler.seeableScore = 0;
        //ScoreHandler.RespawnedData = 0f;    //Reseting the death count for the next run
    }

    public void capture()       //Bookmark
    {
        Player.timeCapture = player.BGMControl.BGMSource.time;
        Player.spawnPos = player.transform.position;
    }

    void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        paused = false;
        Debug.Log("REstart");
    }
}
