using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    public WheelCollider[] WheelsCol;
    public Transform[] WheelMesh;

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxBrakeTorque;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < WheelsCol.Length; i++)
	{
	    WheelsCol[i].transform.position = WheelMesh[i].position;
	}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
	float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
	float brake = maxBrakeTorque * 5;

	WheelsCol[0].steerAngle = steering;
	WheelsCol[1].steerAngle = steering;

	if(Input.GetKey("space"))
	{
	   WheelsCol[0].motorTorque = 0;
	   WheelsCol[1].motorTorque = 0;
	   WheelsCol[0].brakeTorque = brake;
	   WheelsCol[1].brakeTorque = brake;
	}
	else
	{  
	   WheelsCol[0].motorTorque = motor;
	   WheelsCol[1].motorTorque = motor;
	   WheelsCol[0].brakeTorque = 0;
	   WheelsCol[1].brakeTorque = 0;
	}
    }
}
