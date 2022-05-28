using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos;
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - Input.mousePosition.x;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(
                mousePos.x,
                mousePos.y,
                Camera.main.nearClipPlane
            ));
        transform.position = new Vector3(point.x * speed, transform.position.y, transform.position.z);
    }
}
