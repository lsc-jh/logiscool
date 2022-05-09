using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{

    public int score = 0;
    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = "Score: " + score;
    }
}
