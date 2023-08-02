using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject floatingText;
    [SerializeField] private GameObject parent;
    [SerializeField] private Vector3 textOffset=new Vector3(0,0,0);
    public Animator anime;
    public static bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void TakeDamage(int damage)
    {
        health -= damage;
        floatingText.GetComponentInChildren<TextMeshPro>().text = health.ToString();
        Instantiate(floatingText, transform.position + textOffset, Quaternion.identity, transform);
       
        if (health <= 1)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            isDead = true;
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        anime.Play("Flying Back Death");
        yield return new WaitForSeconds(3);
        Destroy(parent);
    }

    private void Die()
    {
        anime.Play("Flying Back Death");
        //Destroy(gameObject,3);
        Destroy(parent);
    }
}
