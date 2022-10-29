using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Transform Player;
    public Transform column;
    public GameObject Platform;
    public GameObject BadPlatfrom;

    private int badChance = 25;

    private GameObject platform;

    private float offset = 0.33f;

    void randomPlatform()
    {
        if (Random.Range(0, 100) < badChance)
        {
            platform = BadPlatfrom;
        }
        else
        {
            platform = Platform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -3; i < 5; i++)
        {
            int platformCount = 0;
            if (Random.Range(0, 2) == 1)
            {
                randomPlatform();
                Instantiate(platform, column.transform.position + new Vector3(-offset, i * 2, offset), Quaternion.Euler(-90, 0, 0), column.transform);
                platformCount++;
            }
            if (Random.Range(0, 2) == 1)
            {
                randomPlatform();
                Instantiate(platform, column.transform.position + new Vector3(offset, i * 2, offset), Quaternion.Euler(-90, 90, 0), column.transform);
                platformCount++;
            }
            if (Random.Range(0, 2) == 1)
            {
                randomPlatform();
                Instantiate(platform, column.transform.position + new Vector3(-offset, i * 2, -offset), Quaternion.Euler(-90, -90, 0), column.transform);
                platformCount++;
            }
            if (platformCount < 3)
            {
                if (Random.Range(0, 2) == 1)
                {
                    randomPlatform();
                    Instantiate(platform, column.transform.position + new Vector3(offset, i * 2, -offset), Quaternion.Euler(-90, 180, 0), column.transform);
                }
            }
            badChance++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
