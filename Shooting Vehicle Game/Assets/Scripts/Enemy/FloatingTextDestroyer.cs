using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextDestroyer : MonoBehaviour
{
    [SerializeField] private float destoyTime=.4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destoyTime);
    }

    
}
