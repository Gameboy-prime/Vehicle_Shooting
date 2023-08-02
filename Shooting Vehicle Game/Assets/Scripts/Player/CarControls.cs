using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{
    

    //WHEEL COLLIDERS
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    //WHEEL TRANFORM
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform rearRightTransform;

    //REFERENCES
    [SerializeField] private float thrustForce;

    [SerializeField] private float wheelSpeed = 2f;
    
    
    private float currentThrust;

    
    void Update()
    {
        
       
        //HandleMotors();
        transform.Translate(Vector3.forward *thrustForce*Time.deltaTime, Space.World);
        
        UpdateWheels();
    }
    
    private void UpdateWheels()
    {
        UpdateSIngleWheels( frontLeftTransform);
        UpdateSIngleWheels(frontRightTransform);
        UpdateSIngleWheels(rearRightTransform);
        UpdateSIngleWheels(rearLeftTransform);
    }

    private void UpdateSIngleWheels(Transform wheelTransform)
    {
        
        wheelTransform.Rotate(new Vector3(1,0,0) * wheelSpeed * Time.deltaTime);
    }


}
