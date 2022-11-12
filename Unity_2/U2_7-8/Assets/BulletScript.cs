using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bounces = 0.0f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "BottomCollider")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name != "BottomCollider" && other.gameObject.name != "Block")
        {
            bounces++;
            if (bounces >= 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
