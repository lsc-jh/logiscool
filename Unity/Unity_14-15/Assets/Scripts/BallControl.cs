using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float Movement = 20f;
    public float JumpForce = 300f;
    public bool CanJump = true;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Movement * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            transform.Translate(-5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetMouseButtonDown(0) && CanJump)
        {
            CanJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 1.5f, 5);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        CanJump = true;
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0, 1.5f, 5);
        }
    }
}
