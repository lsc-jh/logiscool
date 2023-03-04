using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int coinGet;
    private int goalCoin;
    private static int maxCoin;
    public static float speed = 8f;
    private float prevSpeed;
    private float addSpeed;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().tag =="Obstacle")
        {
            Destroy(other.gameObject);
            if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                if (speed > 8) speed /= 1.5f;
                prevSpeed = speed;
                StartCoroutine(GameEnd());
            }
        }

    }
    IEnumerator GameEnd()
    {
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = prevSpeed;
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("SampleScene");
    }
}
