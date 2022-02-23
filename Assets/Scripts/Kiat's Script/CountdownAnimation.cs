using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownAnimation : MonoBehaviour
{
    public Text countdownText;
    public Font fontType;
    public int countdownTime, storeTime;
    private float TimeRemaining;
    private Color textColour;

    // Start is called before the first frame update

    void Start()
    {
        storeTime = countdownTime;
    }

    void OnEnable()
    {
        countdownText = GetComponent<Text>();
        textColour = countdownText.color;
        countdownText.font = fontType;
        textColour.a = 1f;
        countdownText.rectTransform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(animate());
        //Time.timeScale = 0f;
        Debug.Log("active");
    }


    private IEnumerator ScaleUp()
    {
        while (countdownText.rectTransform.localScale.x <= 0.3f)
        {
            countdownText.rectTransform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    private IEnumerator fade()
    {
        while(textColour.a >= 0)
        {
            textColour.a -= 0.1f;
            countdownText.color = textColour;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public IEnumerator animate()
    {
        while(countdownTime >= 1)
        {
            StartCoroutine(ScaleUp());
            StartCoroutine(fade());
            yield return new WaitForSecondsRealtime(1);
            textColour.a = 1f;
            countdownText.rectTransform.localScale = new Vector3(0, 0, 0);
            countdownTime -= 1;
            countdownText.text = countdownTime.ToString();
        }

        countdownText.rectTransform.localScale = new Vector3(0, 0, 0);
        textColour.a = 1f;
        countdownTime = storeTime;
        countdownText.text = countdownTime.ToString();
        this.GetComponentInParent<Image>().raycastTarget = false;
        GameManager.paused = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
