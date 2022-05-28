using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 heading = collision.transform.position - transform.position;
            Vector3 direction = -heading / heading.magnitude;
            rb.velocity = direction * speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
