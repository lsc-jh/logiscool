using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = $"Timer: {time}";
    }
    
    public int time = 0;
    
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time++;
        }
    }
}
