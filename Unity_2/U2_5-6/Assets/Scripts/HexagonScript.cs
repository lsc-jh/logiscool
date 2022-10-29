using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    public float shrink = 3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.forward * Random.Range(0, 360));
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrink * Time.deltaTime;
        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
