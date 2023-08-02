using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MechDamageControl : MonoBehaviour
{
    
    [SerializeField] private int health;
    [SerializeField] private GameObject floatingText;
    
    [SerializeField] private GameObject destMech;
    [SerializeField] private GameObject realObject;

    [SerializeField] private Vector3 textOffset = new Vector3(0, 0, 0);


    public static bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void MechTakeDamage(int damage)
    {
        health -= damage;
        floatingText.GetComponentInChildren<TextMeshPro>().text = health.ToString();
        Instantiate(floatingText, transform.position + textOffset, Quaternion.identity, transform);
       
        if (health <= 1)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<MechRotateToPlayer>().enabled = false;
            isDead = true;
            StartCoroutine(Die());
            
        }
    }

    

    IEnumerator Die()
    {
        GameObject obj=Instantiate(destMech, transform.position, transform.rotation);
        //Destroy(obj, .1f);
        Destroy(realObject);
        yield return new WaitForSeconds(3);
       
        Destroy(obj);
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject, .1f);



    }
}
