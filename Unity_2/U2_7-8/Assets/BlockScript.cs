using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BlockScript : MonoBehaviour
{
    public int healthPoint;

    public GameObject blockText;
    
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = Random.Range(1, 30);
    }

    // Update is called once per frame
    void Update()
    {
        blockText.GetComponent<Text>().text = healthPoint.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            healthPoint -= 1;
        }

        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
