using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    private int playerValue;
    [SerializeField] private GameObject [] cars= new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        playerValue = VehicleSelect.carNum;
        ChooseCar(playerValue);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChooseCar(int num)
    {
        foreach (GameObject obj in cars)
        {
            obj.SetActive(false);
        }
        cars[num].SetActive(true);
    }
}
