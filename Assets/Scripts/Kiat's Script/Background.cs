using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] backgrounds;
    private Vector3 startingPoint;
    private float Xspace;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = new Vector3(0, 0, 100);
        
        for(float x =0; x <= 40; x++)
        {
            int random = Random.Range(0, backgrounds.Length);
            GameObject background = Instantiate(backgrounds[random], startingPoint, Quaternion.identity);
            background.transform.localScale = new Vector3 (0.1025071f, 0.1025071f, 0.1025071f);
            background.transform.SetParent(GetComponent<Transform>());
            startingPoint.x += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
