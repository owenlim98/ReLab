using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public RectTransform panel;
    public Button confirm, cancel;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(QuitGame);
        cancel.onClick.AddListener(Cancel);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            panel.gameObject.SetActive(true);
        }
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("BYE BITCH");
    }

    void Cancel()
    {
        panel.gameObject.SetActive(false);
    }
}
