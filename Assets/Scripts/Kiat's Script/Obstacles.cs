using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    public GameObject lazer, topHolder, btmHolder;  
    public Sprite[] coloursLazers;
    public Sprite[] obstaclesSprites;

    public string lazerColour;
    private SpriteRenderer LRenderer, TRenderer, BtmRenderer;

    // Use this for initialization
    void Start() {
        LRenderer = lazer.GetComponent<SpriteRenderer>();
        TRenderer = topHolder.GetComponent<SpriteRenderer>();
        BtmRenderer = btmHolder.GetComponent<SpriteRenderer>();

        int i = Random.Range(0, coloursLazers.Length);
        LRenderer.sprite = coloursLazers[i];
        TRenderer.sprite = obstaclesSprites[i];
        BtmRenderer.sprite = obstaclesSprites[i];

        if(i == 0)
        {
            lazerColour = "Red";
        }
        else if(i == 1)
        {
            lazerColour = "Blue";
        }
        else
        {
            lazerColour = "Green";
        }

    }
}
