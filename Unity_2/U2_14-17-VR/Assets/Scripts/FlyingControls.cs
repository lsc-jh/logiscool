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

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == checkpoints[0])
        {
            checkpoints.RemoveAt(0);
            Destroy(other.gameObject);
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
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator Win()
    {
        WinText.enabled = true;
        yield return new WaitForSeconds(3);
        WinText.enabled = false;
        StartCoroutine(Fading());
    }
}
