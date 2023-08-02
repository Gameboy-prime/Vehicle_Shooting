using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustCal : MonoBehaviour
{
    public static float speed;
    public float value = 16;
    private float milli;
    private float Seconds;
    // Start is called before the first frame update
    void Start()
    {
        speed = value;
    }

    // Update is called once per frame
    void Update()
    {
        milli += Time.deltaTime * 10;
        if (milli > 10)
        {
            Seconds += 1;
            milli= 0;
        }
        if (Seconds > 50)
        {
            Seconds= 0;
            IncreaseSpeed();
        }
        
        
        
    }

    private void IncreaseSpeed()
    {
        speed += 2;
        GenerateLevel.destroyTime++;
        
        

    }
}
