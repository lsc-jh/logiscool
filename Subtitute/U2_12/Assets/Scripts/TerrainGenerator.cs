using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int Depth = 20;
    private int width = 256;
    private int height = 256;

    public float Scale = 20f;
    public float OffsetX = 100f;
    public float OffsetY = 100f;

    private Terrain terrain;
    
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        OffsetX = Random.Range(0, 9999f);
        OffsetY = Random.Range(0, 9999f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            terrain.terrainData = GenTerrain(terrain.terrainData);
            OffsetX += Time.deltaTime * 5f;
        }

        if (Input.GetKey("g"))
        {
            terrain.terrainData = GenTerrain(terrain.terrainData);
            OffsetX = Random.Range(0, 9999f);
            OffsetY = Random.Range(0, 9999f);
        }
    }

    float GetHeight(int x, int y)
    {
        var xPos = (float)x / width * Scale + OffsetX;
        var yPos = (float)y / height * Scale + OffsetY;
        return Mathf.PerlinNoise(xPos, yPos);
    }

    float[,] GenHeight()
    {
        var heights = new float[width, height];
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < width; j++)
            {
                heights[i, j] = GetHeight(i, j);
            }
        }

        return heights;
    }

    TerrainData GenTerrain(TerrainData data)
    {
        data.heightmapResolution = width + 1;
        data.size = new Vector3(width, Depth, height);
        data.SetHeights(0, 0, GenHeight());
        return data;
    }
}
