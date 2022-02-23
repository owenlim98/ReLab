using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPosition : MonoBehaviour
{
    public Toggle toggle;
    public Slider progressbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            progressbar.transform.localPosition = new Vector3(0, 470, 78);
        }

        else
        {
            progressbar.transform.localPosition = new Vector3(0, -470, 78);
        }
    }
}
