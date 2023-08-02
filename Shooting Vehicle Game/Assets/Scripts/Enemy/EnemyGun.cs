using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Transform shootingOrigin;
    private RaycastHit hit;
    [SerializeField] private LayerMask shootable;

    [SerializeField] private float timeBetweenShooting;

    [SerializeField] private int damage;

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject bulletHole;
    public string shootText;

    public Animator shootingAnim;

    private bool readyToShoot;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToShootingPos()
    {
        transform.localPosition = new Vector3(-0.31f, 0.18f, 0.01f);
        transform.localRotation = Quaternion.Euler(-17.3f, -74.11f, 122.9f);
    }

    public void InvokeShoot()
    {
        if (!DamageControl.isDead)
        {

            Shoot();
        }




    }

    private void Shoot()
    {
        shootingAnim.Play(shootText);
        
        readyToShoot = false;
        if (Physics.Raycast(shootingOrigin.position, shootingOrigin.forward, out hit, 100, shootable))
        {
            if (hit.collider != null)
            {
                //TAkeDamage
                if (hit.collider.tag == "Player")
                {
                    //hit.collider.GetComponent<PlayerDamage>().TakeDamage(damage);
                }
                Debug.Log(hit.collider.name);
            }
        }
        
        GameObject flash = Instantiate(muzzleFlash, shootingOrigin.position, Quaternion.identity);
        GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.identity);
        Destroy(flash, .2f);
        Destroy(hole, .5f);



        
       
    }

    private void ShootReset()
    {
        readyToShoot = true;
    }
}
