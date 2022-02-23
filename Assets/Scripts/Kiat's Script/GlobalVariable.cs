using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariable : MonoBehaviour
{
    public static float soundControl = 100f;
    public static GlobalVariable instance; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //private void Update()
    //{
    //    Debug.Log(soundControl);
    //}
}
