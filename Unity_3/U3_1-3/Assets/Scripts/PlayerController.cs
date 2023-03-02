using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f){
            transform.position += Vector3.left * 1f;
        }

        if(Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f){
            transform.position += Vector3.right * 1f;
        }
    }
}
