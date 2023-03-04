using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3f, 0);
        transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.forward,
        Mathf.Round(PlayerController.speed)*Time.deltaTime);
        
        if(transform.position.z <= -9)
        {
            ObjectPools.Instance.ReturnToPool(this);
        }
    }
}
