using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject HexaPrefab;

    private float spawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            Instantiate(HexaPrefab);
            spawnTime = Time.time + 1f / spawnRate;
        }
    }
}
