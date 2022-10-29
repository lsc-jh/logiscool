using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private bool hasCollide = false;
    private Vector3 jumpForce = new Vector3(0, 5, 0);

    public Text LevelText;
    public Text BestLevelText;

    private int level = 1;
    private int bestLevel = 1;

    private void Update()
    {
        if (bestLevel < level) bestLevel = level;
        LevelText.text = $"Level: {level}";
        BestLevelText.text = $"Best Level: {bestLevel}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "badPlatform")
        {
            level = 1;
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.gameObject.name == "platform_full")
        {
            level++;
            SceneManager.LoadScene("SampleScene");
        }
        
        if (!hasCollide)
        {
            hasCollide = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
            StartCoroutine(Reset());
        }
    }
    IEnumerator Reset()
    {    
        yield return new WaitForSeconds(0.1f);
        hasCollide = false;
    }
}
