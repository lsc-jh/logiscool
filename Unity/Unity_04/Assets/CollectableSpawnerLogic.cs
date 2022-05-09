using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerLogic : MonoBehaviour
{

    public GameObject collectable;
    public GameObject badCollectable;

    public float collectableSpawnTime = 1f;
    public float badCollectableSpawnTime = 2f;

    float randomXCollectable = 0;
    float randomYCollectable = 0;

    float randomXBadCollectable = 0;
    float randomYBadCollectable = 0;

    float maxX = 17.5f;
    float maxY = 9f;
    // Start is cf;alled before the first frame update
    void Start()
    {
        StartCoroutine(spawnBadCollectables());
        StartCoroutine(spawnCollectables());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnCollectables()
    {
        while (true)
        {
            spawnCollectable();
            yield return new WaitForSeconds(collectableSpawnTime);
        }
    }

    IEnumerator spawnBadCollectables()
    {
        while (true)
        {
            spawnBadCollectable();
            yield return new WaitForSeconds(badCollectableSpawnTime);
        }
    }

    void spawnCollectable()
    {
        randomXCollectable = Random.Range(-maxX, maxX);
        randomYCollectable = Random.Range(-maxY, maxY);

        Instantiate(collectable, new Vector3(randomXCollectable, randomYCollectable, 0), Quaternion.identity);
    }

    void spawnBadCollectable()
    {
        randomXBadCollectable = Random.Range(-maxX, maxX);
        randomYBadCollectable = Random.Range(-maxY, maxY);

        Instantiate(badCollectable, new Vector3(randomXBadCollectable, randomYBadCollectable, 0), Quaternion.identity);
    }
}
