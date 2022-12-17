using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenTerrain : MonoBehaviour
{

    public GameObject tPrefab;

    public void MakeTerrain()
    {
        Instantiate(tPrefab, new Vector3(-130f, -250f, 0), Quaternion.identity);
    }
}
