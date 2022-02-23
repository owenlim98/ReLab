using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXToggle : MonoBehaviour
{
    public Toggle sfxToggle;
    public Slider slider;
    public static float BGMVolume;
    public static bool muted;

    void Start()
    {
        slider.value = GlobalVariable.soundControl * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        mute();
        BGMVolume = slider.value;
        GlobalVariable.soundControl = BGMVolume / 100;
    }

    void mute()
    {
        muted = !sfxToggle.isOn;
    }
    
}
