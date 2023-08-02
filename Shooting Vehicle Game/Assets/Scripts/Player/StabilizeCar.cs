using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilizeCar : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelL;
    [SerializeField] private WheelCollider wheelR;
    [SerializeField] private Rigidbody car;
    [SerializeField] private float antiRollForce;


    private void Start() => car = GetComponent<Rigidbody>();


    private void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
        }

        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        float rollForce = travelL - travelR;

        if (groundedL)
        {
            car.AddForceAtPosition(wheelL.transform.up * rollForce, wheelL.transform.position);
        }

        if (groundedR)
        {
            car.AddForceAtPosition(wheelR.transform.up * rollForce, wheelR.transform.position);
        }
    }
}
