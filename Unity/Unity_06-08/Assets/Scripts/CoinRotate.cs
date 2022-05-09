using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    
    public float delta = 0.5f;
    public float speed = 3.0f;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
	Vector3 v = startPos;
	v.y += delta * Mathf.Sin(Time.time * speed);
	transform.position = v;
    }
}
