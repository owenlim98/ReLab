using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickAnimation : MonoBehaviour
{
    private Button stage1;
    public Animator animate;
    public RuntimeAnimatorController controller;

    // Start is called before the first frame update
    void Start()
    {
        stage1 = GetComponent<Button>();
        animate = GetComponent<Animator>();
        stage1.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        animate.runtimeAnimatorController = controller;
        animate.enabled = true;
    }
}
