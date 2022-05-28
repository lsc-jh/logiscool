using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    public float Movement = 20f;
    public float JumpForce = 300f;
    public bool CanJump = true;

    public Text Level;
    public Text BestLevel;
    private int levelNum;
    private int bestLevelNum;

    private void Start()
    {
        levelNum = 1;
        bestLevelNum = 1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Movement * Time.deltaTime);
        transform.Translate(Input.acceleration.x, 0, 0);
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
            levelNum = 1;
            Movement = 20f;
            Level.text = "Level " + levelNum;
            Debug.Log("Level " + levelNum);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        CanJump = true;
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0, 1.5f, 5);
            levelNum = 1;
            Movement = 20f;
            Level.text = "Level " + levelNum;
            Debug.Log("Level " + levelNum);
        }
        if (collision.gameObject.tag == "Finish")
        {
            transform.position = new Vector3(0, 1.5f, 5);
            levelNum += 1;
            Movement += 5;
            if (levelNum > bestLevelNum)
            {
                bestLevelNum = levelNum;
            }
            Level.text = "Level " + levelNum;
            BestLevel.text = "Best Level: " + bestLevelNum;
            Debug.Log("Level " + levelNum);
            Debug.Log("Best Level: " + bestLevelNum);
        }
    }
}
