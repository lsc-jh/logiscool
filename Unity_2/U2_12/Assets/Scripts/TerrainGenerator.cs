using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;

    private int width = 256;
    private int height = 256;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    Terrain terrain;

    float GetHeight(int x, int y)
    {
        float xPos = (float)x / width * scale + offsetX;
        float yPos = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xPos, yPos);
    }

    float[,] GenHeight()
    {
        var heights = new float[width, height];
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                heights[i, j] = GetHeight(i, j);
            }
        }
        return heights;
    }

    TerrainData GenTerrain(TerrainData data)
    {
        data.heightmapResolution = width + 1;
        data.size = new Vector3(width, depth, height);
        data.SetHeights(0, 0, GenHeight());
        return data;
    }

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }

    // Update is called once per frame
    void Update()
    {
        terrain.terrainData = GenTerrain(terrain.terrainData);
        offsetX += Time.deltaTime * 5f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            terrain.terrainData = GenTerrain(terrain.terrainData);
            offsetY -= Time.deltaTime * 3f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            terrain.terrainData = GenTerrain(terrain.terrainData);
            offsetY += Time.deltaTime * 3f;
        }

        if (Input.GetKey("g"))
        {
            terrain.terrainData = GenTerrain(terrain.terrainData);
            offsetX = Random.Range(0f, 9999f);
            offsetY = Random.Range(0f, 9999f);
        }

    }
}
