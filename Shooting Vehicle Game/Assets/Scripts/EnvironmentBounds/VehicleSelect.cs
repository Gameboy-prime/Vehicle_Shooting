using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelect : MonoBehaviour
{
    [SerializeField] private  GameObject[] cars = new GameObject[6];
    public static int carNum;
    // Start is called before the first frame update
    void Start()
    {
        carNum= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (carNum == 0)
        {
            foreach (GameObject obj in cars)
            {
                obj.SetActive(false);
            }
            cars[carNum].SetActive(true);
        }

    }

    public void ChangeCar()
    {
        
        carNum++;
        if (carNum > 5)
        {
            carNum= 0;
        }
        Changer(carNum);
        Debug.Log(carNum);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    private void Changer(int num)
    {
        foreach (GameObject obj in cars)
        {
            obj.SetActive(false);
        }
        cars[num].SetActive(true);
    }

    
}
