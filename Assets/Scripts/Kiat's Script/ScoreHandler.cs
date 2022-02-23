using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public GameObject EndScreen;
    public Text status, stageScoreText, RespawnedText, BonusText, FinalScoreText, SeenScore;
    public static float RespawnedData, BonusData, FinalScoreData;
    public static int seeableScore, obstacleScore;
    public static float songTime;
    public static string StageStatus;
    private int songTimeInt;

    // Start is called before the first frame update
    void Start()
    {
        BonusData = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        status.text = StageStatus;
        SeenScore.text = (obstacleScore + seeableScore).ToString();
        songTimeInt = obstacleScore + seeableScore;
        stageScoreText.text = songTimeInt.ToString();
        RespawnedText.text = RespawnedData.ToString();
        BonusText.text = BonusData.ToString();
        FinalScoreData = (songTimeInt - RespawnedData) * BonusData;

        if(FinalScoreData < 0)
        {
            FinalScoreData = 0;
        }

        FinalScoreText.text = FinalScoreData.ToString();

        if(StageStatus == "Clear")
        {
            EndScreen.transform.position = transform.position;
        }
    }
}
