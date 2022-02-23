using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button gamemode, characterscreen, optionscreen;

    void Start()
    {
        optionscreen.onClick.AddListener(loadOptionMenu);
        gamemode.onClick.AddListener(loadGameModeMenu);
        characterscreen.onClick.AddListener(characterMenu);
        SFXToggle.BGMVolume = 100;
        SFXToggle.muted = false;
    }

    void loadGameModeMenu()
    {
        SceneManager.LoadScene("Gamemodes");
    }

    void loadOptionMenu()
    {
        SceneManager.LoadScene("OptionMenu");
        BackButtons.previousScene = "MainMenu";
    }

    void characterMenu()
    {
        SceneManager.LoadScene("CharacterScreen");
    }
}
