using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MechRotateToPlayer : MonoBehaviour
{
    private Transform car;
    [SerializeField] private float radius;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float timeBetweenShooting;
    private float milli;
    private float sec;

    
    public MechEnemyGun mechEnemyGun;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        car= CarManager.instance.car.transform;
        float distance= Vector3.Distance(transform.position, car.position);
        if(distance<radius)
        {
            RotateTowards();
            
            milli += Time.deltaTime * 10;
            if (milli > 9)
            {
                sec++;
                milli = 0;
                if (sec > timeBetweenShooting)
                {
                    mechEnemyGun.InvokeShoot();


                }

            }
            
            
            
        }
        Debug.Log(Time.unscaledTime);
        
        
        
    }

    

    private void RotateTowards()
    {
        Vector3 direction= (car.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime* rotSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
