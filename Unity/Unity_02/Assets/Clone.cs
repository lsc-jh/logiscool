using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject BallPrefab;
    public int BallAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < BallAmount; i++)
        {
            GameObject ballObject = Instantiate(BallPrefab);
            ballObject.transform.position = new Vector3(
                Random.Range(-10, 10),
                Random.Range(5, 10),
                Random.Range(10, 20)
            );
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
