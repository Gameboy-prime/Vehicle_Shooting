using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Animator anime;
    [SerializeField] private int magSize, bulletLeft, bulletShot;
    [SerializeField] private float reloadTime, timeBetweenShooting, range, timeBetweenShot=0.1f;

    private bool allowButtonHold, readyToShoot, isShooting, reloading;

    public RaycastHit hit;
    public LayerMask shootables;

    public Transform attackPoint;

    //Effects

    [SerializeField] private GameObject muzzleFlash, bulletHoleGraphics;

    void Start(){
        readyToShoot= true;
        bulletLeft= magSize;

    }



    void Update()
    {
        
        // if(Input.touchCount>0)
        // {
        //     Touch touch= Input.GetTouch(0);
        //     if(touch.position.x>(Screen.width/2) && bulletLeft>0 && touch.position.y< (Screen.height/2) && !reloading && readyToShoot)
        //     {
        //         Shoot();

        //     }

        //     if(touch.position.x>(Screen.width/2) && bulletLeft>0 && touch.position.y> (Screen.height/2) && bulletLeft<magSize)
        //     {
        //         Debug.Log("Reload Button was pressed");
        //         Reload();

        //     }
            
            
        // }

        StartCoroutine(Shoot());
    }

    public void ShootTrigger(){
        isShooting= true;
    }

    public void DontShootTrigger(){
        isShooting=false;
    }

    IEnumerator Shoot()
    {

        if(isShooting && readyToShoot)
        {
            anime.Play("Shoot Rifle");
            yield return new WaitForSeconds(timeBetweenShot);
            readyToShoot=false;

            
            //Don't forget to put isshooting
        
            if(Physics.Raycast(transform.position,transform.forward, out  hit, range, shootables))
            {
                if(hit.collider!=null)
                {
                    //hit.collider.GetComponent<EnemyDamage>().TakeDamge();
                    Debug.Log("It has hit an enemy");

                }
            }

            bulletLeft--;
            bulletShot--;



            GameObject obj=Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity );
            GameObject obj1=Instantiate(bulletHoleGraphics, hit.point, Quaternion.identity);
            Destroy(obj, .2f);
            Destroy(obj1, .2f);

            Invoke("ShootReset", timeBetweenShooting);

        }
    }

    private void ShootReset()
    {
        readyToShoot= true;

    }

    public  void Reload()
    {
        if(!reloading && bulletLeft!=magSize)
        {
            reloading=true;
            bulletLeft = magSize;
            Invoke("ReloadReset", reloadTime);


        }
        
    }

    private void ReloadReset()
    {
        reloading= false;

    }


}
