using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SpawnManager : MonoBehaviour
{
    public static TextAsset spawnXs;
    private string[] spawns;
    private float[] spawnF;
    public GameObject[] obstacles;
    public GameObject endZone;
    public Player player;
    private float SpawnXPos;
    public static float endPoint;

    // Start is called before the first frame update
    void Start()
    {
        string[] spawns = spawnXs.text.Split("\n"[0]);
        player = GetComponent<Player>();

        foreach(string str in spawns)
        {
            int r = Random.Range(0, obstacles.Length);
            SpawnXPos = float.Parse(str);
            Instantiate((GameObject)obstacles[r], new Vector3(SpawnXPos + 2.5f, -3.34f, 0), Quaternion.identity);
        }

        endPoint = SpawnXPos;
        Instantiate((GameObject)endZone, new Vector3(SpawnXPos + 10f, 0, 0), Quaternion.identity);

    }
}
