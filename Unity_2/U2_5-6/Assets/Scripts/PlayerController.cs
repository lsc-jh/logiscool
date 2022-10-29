using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 300f;

    public float rotationRate = 7.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComputerInput();
        MobileInput();
    }

    void ComputerInput()
    {
        if (Input.GetKey("left"))
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right")) // left --> right
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, -moveSpeed * Time.deltaTime);
        }
    }

    void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, rotationRate / 10);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("SampleScene");
    }

}
