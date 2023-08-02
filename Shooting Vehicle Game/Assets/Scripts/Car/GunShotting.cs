using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunShotting : MonoBehaviour
{
    //Stats
    [SerializeField] private int clipSIze,bulletLeft, damage;
    [SerializeField] private int magazineSize;
    [SerializeField] private float reloadTime, timeBetweenShots;
    private int bulletShot;


    [SerializeField] private bool allowButtonHold;

    private bool IsShooting;
    private bool readyToShoot;
    private bool reloading;

    //EFFECTS
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject bulletHole;


    //REFERENCES
    [SerializeField] private Transform shootingOrigin;
    [SerializeField] private LayerMask shootable;
    [SerializeField] private RaycastHit hit;

    //UI

    [SerializeField] private TextMeshProUGUI bulletLeftBox;
    [SerializeField] private TextMeshProUGUI magazineBox;

    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
        bulletLeft = clipSIze;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        bulletLeftBox.GetComponent<TextMeshProUGUI>().text= "Bullet Left " + bulletLeft.ToString();
        magazineBox.GetComponent<TextMeshProUGUI>().text = "Magazine Size " + magazineSize.ToString(); 
    }

    private void Inputs()
    {
        IsShooting = Input.GetKeyDown(KeyCode.Mouse0);
        /*if (allowButtonHold)
        {
            IsShooting = Input.GetKey(KeyCode.Mouse0);
        }

        else
        {
            IsShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }*/
        if(IsShooting && readyToShoot && !reloading && bulletLeft>0)
        {
            Shoot();

        }
        

        if(Input.GetKeyDown(KeyCode.R)  && bulletLeft<clipSIze)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        if(Physics.Raycast(shootingOrigin.position, transform.forward,out hit, Mathf.Infinity, shootable))
        {
            if(hit.collider != null)
            {
                //TAkeDamage
                if (hit.collider.tag == "Enemy")
                {
                    
                    hit.collider.GetComponent<DamageControl>().TakeDamage(damage);
                }
                else if(hit.collider.tag == "Enemy2")
                {
                    hit.collider.GetComponent<MechDamageControl>().MechTakeDamage(damage);
                }
                else
                {
                    Debug.Log(hit.collider.name);
                }
                Debug.Log(hit.collider.name);
            }
        }
        bulletLeft--;
        bulletShot--;
        GameObject flash= Instantiate(muzzleFlash, shootingOrigin.position, Quaternion.identity);
        GameObject hole= Instantiate(bulletHole, hit.point, Quaternion.Euler(0,180,0));
        hole.transform.position += hole.transform.position / 1000;
        Destroy(flash, .2f);
        Destroy(hole, .7f);
        
        Debug.Log(bulletLeft);
        Invoke("ShootReset", timeBetweenShots);
        //Invoke("Shoot", timeBetweenShots);
    }

    private void ShootReset()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading= true;
        Invoke("ReloadReset", reloadTime);
        reloading= false;

    }
    private void ReloadReset()
    {
        int value;
        if (bulletLeft < clipSIze)
        {
            value = clipSIze - bulletLeft;
        }
        
        if(magazineSize < clipSIze)
        {
            value=magazineSize;
        }
        else
        {
            value = clipSIze;
        }
        bulletLeft = value;
        magazineSize= value;
    }
}
