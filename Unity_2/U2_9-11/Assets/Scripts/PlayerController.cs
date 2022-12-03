using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 55f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "platform")
        {
            GetComponent<CharacterController>().Move(
                hit.transform.forward * (PlatformController.moveSpeed / 4f) * Time.deltaTime);
        }

        if (hit.gameObject.tag == "Car")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
