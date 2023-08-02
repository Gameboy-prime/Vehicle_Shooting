//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private GameObject glowObject;
    [SerializeField] private float bounds;
    [SerializeField] private float delay;
    [SerializeField] private Transform initialPos;
    [SerializeField] private float propelSpeed=200f;
    // Start is called before the first frame update

    void Update()
    {
        StartCoroutine(SpawnGlow());
    }

    IEnumerator SpawnGlow()
    {
        while (true)
        {
            
            float pointY = Random.Range(-bounds, bounds);
            float pointX = Random.Range(-bounds, bounds);
            
            
            GameObject obj = Instantiate(glowObject, initialPos.position + new Vector3(pointX,pointY, 0), Quaternion.identity);
            yield return null;
            obj.GetComponent<Rigidbody>().AddForce(-Vector3.forward*propelSpeed,ForceMode.Impulse);
            Destroy(obj, 3f);
            
            yield return new WaitForSeconds(delay);
        }

    }

}
