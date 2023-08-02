using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurnBody : MonoBehaviour
{
    private Transform car;
    [SerializeField] private float radius;
    [SerializeField] private float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //car = CarManager.instance.car.transform;
        car = FindObjectOfType<CarControls>().gameObject.transform;
        float distance = Vector3.Distance(transform.position, car.position);
        if (distance < radius)
        {
            RotateTo(car);
            

            
            

        }
    }

    private void RotateTo(Transform carPos)
    {

        Quaternion rot = Quaternion.LookRotation(transform.position - carPos.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, rotSpeed*Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }




}
