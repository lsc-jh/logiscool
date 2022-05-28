using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
public class HitTheBlock : MonoBehaviour
{
    public int health;
 
    private Color[] colors =
    {
        new Color(255, 0, 0, 255),
        new Color(255, 127, 0, 255),
        new Color(255, 255, 0, 255),
        new Color(0, 255, 0, 255),
        new Color(0, 255, 255, 255)
    };
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            health--;
            if (health == 0) 
                Destroy(gameObject);
            else
                GetComponent<Renderer>().material.color = colors[health - 1];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = colors[health - 1];
 
    }
 
    // Update is called once per frame
    void Update()
    {
 
    }
}
