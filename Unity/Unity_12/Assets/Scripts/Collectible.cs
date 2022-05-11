using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject door;
    public int collectiblesLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            collectiblesLeft--;
            Destroy(other.gameObject);
            if(collectiblesLeft  <= 0)
            {
                Destroy(door);
            }
        }
    }
}
