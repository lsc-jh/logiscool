using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float Movement = 20f;
    public float JumpForce = 300f;
    public bool CanJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, Movement * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            this.transform.Translate(-Movement * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            this.transform.Translate(Movement * Time.deltaTime, 0, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
