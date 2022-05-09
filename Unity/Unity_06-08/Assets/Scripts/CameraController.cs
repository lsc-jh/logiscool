using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera gameCamera;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(
	   Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, 0.3f),
	   player.transform.position.y,
	   Mathf.Lerp(gameCamera.transform.position.z, player.transform.position.z - 15, 0.01f)
	);
    }
}
