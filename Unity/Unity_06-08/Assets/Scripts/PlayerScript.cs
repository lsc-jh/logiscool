using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
public float moveForce;
    public float jumpForce;
    private bool canJump = false;
    private bool hasSwitchedLayer = false;

    public GameObject GUI;
    private int CoinCount = 0;
    private bool game = true;

    // Start is called before the first frame update
    void Start()
    {
    	moveForce = 250;	
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	if (Input.GetKey("a"))
	{
	    GetComponent<Rigidbody>().velocity = new Vector3(
	    -moveForce * Time.deltaTime, 
	    GetComponent<Rigidbody>().velocity.y,
	    GetComponent<Rigidbody>().velocity.z);	    
	}
        
    	if (Input.GetKey("d"))
	{
	    GetComponent<Rigidbody>().velocity = new Vector3(
	    moveForce * Time.deltaTime, 
	    GetComponent<Rigidbody>().velocity.y,
	    GetComponent<Rigidbody>().velocity.z);	    
	}

	if(Input.GetKey("w") && canJump)
	{
	    canJump = false;
	    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
	}

    }

    void Update()
    {
	if(game)
	{
	    GUI.GetComponent<Text>().text = "Coin: " + CoinCount.ToString();
	}
	if(this.transform.position.y < -50)
	{
	    this.transform.position = new Vector3(-17, 2, 0);
	    hasSwitchedLayer = false;
	}

	if(Input.GetKeyDown("space"))
	{
	    if(hasSwitchedLayer)
	    {
	        this.transform.position = new Vector3 (
		    this.transform.position.x,
		    this.transform.position.y,
		    0);	
	    } else 
	    {
		    
	        this.transform.position = new Vector3 (
		    this.transform.position.x,
		    this.transform.position.y,
		    10);	
	    }
	    hasSwitchedLayer = !hasSwitchedLayer;
	}
    }

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
     	if(collision.gameObject.name == "Finish1")
	{
	    this.transform.position = new Vector3(27, 2, 0);
	    hasSwitchedLayer = false;
	}
	if(collision.gameObject.name == "Finish2")
	{
	   Destroy(collision.gameObject);
	   game = false;
	   GUI.GetComponent<Text>().text = "GameOver!";
	   GUI.GetComponent<Text>().color = Color.blue;
	   GUI.GetComponent<Text>().fontSize = 100;
	   GUI.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

	}

	if(collision.gameObject.tag == "Obstacles")
	{
	    this.transform.position = new Vector3(-17, 2, 0);
	    hasSwitchedLayer = false;
	}
	if(collision.gameObject.tag == "Trampoline")
	{
	    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 600, 0));
	}
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
	{
	    Destroy(other.gameObject);
	    CoinCount += 1;
	}
    }


}
