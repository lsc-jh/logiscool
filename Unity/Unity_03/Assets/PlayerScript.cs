using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed = 3;
    public int rotatingSpeed = 140;
    public int jumpForce = 300;

    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotatingSpeed * Time.deltaTime);
        }

        if(Input.GetKey("space") && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Floor")
        {
            canJump = true;
        }
    }
}
