using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamemodeBack : MonoBehaviour
{
    public Button backbutton;

    void Start()
    {
        backbutton.onClick.AddListener(loadback);
    }

    void loadback()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
