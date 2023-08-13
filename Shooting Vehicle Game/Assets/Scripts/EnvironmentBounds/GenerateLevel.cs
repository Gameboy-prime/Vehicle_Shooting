using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionsCity;
    
    

    public float zPos=50f;
    public int secNum;
    public bool hasSpawned;
    

    //public Transform spawnAxis;
    public Transform pointSpawn;

    
    public static float destroyTime;
    public float SpawnTime = 3f;
    public float elapsedTime;

    [SerializeField] private int rand=3;

    private void Start()
    {
        
        elapsedTime = SpawnTime;
    }

    void Update()
    {

        
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0 && !hasSpawned)
        {
            LevelGen();
            elapsedTime = SpawnTime;
            hasSpawned = false;
        }



    }

   

    private void LevelGenCity()
    {
        secNum = Random.Range(0, rand);
        GameObject obj = Instantiate(sectionsCity[secNum], pointSpawn.position, Quaternion.identity);
        pointSpawn.position = new Vector3(obj.transform.position.x, 0, obj.transform.position.z + zPos);

    }

    private void LevelGen()
    {
        //This is used to generate a paricular Scene
        LevelGenCity();
        
    }

    public void ResetSpawnPoint()
    {
        //THis is used to reset the position of the spwan point when a new scene is activated
        //I subtracted 50 Because that is the initial distance
        float pointZ= pointSpawn.position.z-zPos;
        pointSpawn.position -= new Vector3(0, 0, pointZ);
    }



}
