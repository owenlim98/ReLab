using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public Button loadlevelselection;

    void Start()
    {
        loadlevelselection.onClick.AddListener(loadlevel);
    }

    void loadlevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
