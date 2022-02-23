using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNavigationButton : MonoBehaviour
{
    public Button leftButton, rightButton;
    public Button[] stages;
    public Text highscore, score;

    public static int stageNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        leftButton.onClick.AddListener(PreviousStage);
        rightButton.onClick.AddListener(NextStage);

        foreach (Button btn in stages)
        {
            btn.onClick.AddListener(loadLevel);
        }

        BackButtons.previousScene = "Gamemodes";
    }

    void Update()
    {
        if(stageNum == 0 || stageNum == stages.Length - 1)
        {
            highscore.gameObject.SetActive(false);
        }

        else
        {
            highscore.gameObject.SetActive(true);
        }
    }

    void PreviousStage()
    {
        if(stageNum == 0)
        {
            stages[stageNum].gameObject.SetActive(false);
            stageNum = stages.Length - 1;
            stages[stageNum].gameObject.SetActive(true);
        }

        else
        {
            stages[stageNum].gameObject.SetActive(false);
            stageNum--;
            stages[stageNum].gameObject.SetActive(true);
        }
    }

    void NextStage()
    {
        if (stageNum == stages.Length - 1)
        {
            stages[stageNum].gameObject.SetActive(false);
            stageNum = 0;
            stages[stageNum].gameObject.SetActive(true);
        }

        else
        {
            stages[stageNum].gameObject.SetActive(false);
            stageNum++;
            stages[stageNum].gameObject.SetActive(true);
        }
    }

    void loadLevel()
    {
        if(stageNum == 0)
        {
            SceneManager.LoadScene("Tutorial");
            return;
        }
        if(stageNum <= stages.Length - 2)
        {
            SceneManager.LoadScene("GamePlay");
        } 
    }
}
