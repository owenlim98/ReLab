using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    public AudioSource BGMSource;
    public AudioClip[] StageSongs;
    public static bool[] Switches;
    public TextAsset[] StageSpawns;
    private int counter;
    private float time;
    public Slider progressBar;


    // Use this for initialization
    void Start () {
        ScoreHandler.seeableScore = 0;
        BGMSource = GetComponent<AudioSource>();
        BGMSource.clip = StageSongs[LevelNavigationButton.stageNum - 1];
        SpawnManager.spawnXs = StageSpawns[LevelNavigationButton.stageNum -1];
        GameManager.paused = false;     
        ScoreHandler.songTime = BGMSource.clip.length * 10f;
        progressBar.value = 0;
        BGMSource.Play();
        StartCoroutine(startCounter());
	}
	
	// Update is called once per frame
	void Update () {
        BGMSource.volume = GlobalVariable.soundControl;
        if (GameManager.paused == true || Player.dead == true)
        {
            BGMSource.Pause();
        }
        else
        {
            BGMSource.UnPause(); 
        }
        time = BGMSource.time;
        //int IntTime = Mathf.RoundToInt(time);
        progressBar.value = (time / BGMSource.clip.length) * 100;

        if(BGMSource.isPlaying == false && GameManager.paused != true)    //To keep it at max value even when the song ended
        {
            progressBar.value = progressBar.maxValue;
        }
        
        if(ScoreHandler.StageStatus == "Clear")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator startCounter()
    {
        while (BGMSource.isPlaying == true)
        {
            ScoreHandler.seeableScore += 10;
            yield return new WaitForSeconds(1);
        }
    }
}
