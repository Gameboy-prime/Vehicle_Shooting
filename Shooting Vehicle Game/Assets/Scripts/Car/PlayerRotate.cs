using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Mouse1))
        {
            player.transform.Rotate(new Vector3(0, mouseX, 0), Space.World);
            player.transform.Rotate(new Vector3(-mouseY, 0, 0), Space.Self);
        }
        
    }
}
