using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.05f),
            Mathf.Lerp(transform.position.y, Player.transform.position.y, 0.05f),
            -1
        );
    }
}
