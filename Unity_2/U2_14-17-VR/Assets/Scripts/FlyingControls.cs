using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyingControls : MonoBehaviour
{

    public float baseSpeed;

    private float speed;

    public Image blackScreen;
    public Animator animator;

    public Transform CheckpointsObject;
    private List<Transform> checkpoints = new List<Transform>();
    public Text WinText;
    
    private float timeLeft = 10f;
    public Text TimerText;
    public bool round = false;

    // Start is called before the first frame update
    void Start()
    {
        round = true;
        WinText.enabled = false;
        for (var i = 0; i < CheckpointsObject.childCount; i++)
        {
            checkpoints.Add(CheckpointsObject.GetChild(i));
            checkpoints[i].gameObject.SetActive(false);
        }
        checkpoints[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        speed = baseSpeed + GvrVRHelpers.GetHeadRotation().x * 10;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + GvrVRHelpers.GetHeadForward(), speed * Time.deltaTime);

        if (timeLeft > 0 && round)
        {
            timeLeft -= Time.deltaTime;
            TimerText.text = $"Time left: {Math.Round(timeLeft, 1)}";
        }
        else
        {
            if (round)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == checkpoints[0])
        {
            checkpoints.RemoveAt(0);
            Destroy(other.gameObject);

            timeLeft += 5f;
            
            if (checkpoints.Count == 0)
            {
                Debug.Log("Win");
                StartCoroutine(Win());
            }
            else
            {
                checkpoints[0].gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        baseSpeed = 0;
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        if (round)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("Level2");
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator Win()
    {
        round = false;
        baseSpeed = 0;
        TimerText.text = $"Finished: {Math.Round(timeLeft, 1)}";
        
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            WinText.text = "Level 1 Completed!";
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            WinText.text = "Level 2 Completed!";
        }
        else
        {
            WinText.text = "You Completed the Game!";
        }
        
        WinText.enabled = true;
        yield return new WaitForSeconds(3);
        WinText.enabled = false;
        StartCoroutine(Fading());
    }
}
