using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtons : MonoBehaviour
{
    public Button backbutton;
    public static string previousScene;

    void Start()
    {
        backbutton.onClick.AddListener(loadback);
    }


    void loadback()
    {
        SceneManager.LoadScene(previousScene);
    }
}
