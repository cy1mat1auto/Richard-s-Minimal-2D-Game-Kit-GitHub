using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike01 : MonoBehaviour
{
    //A simple script for damaging the player, assuming the script is attached to a gameobject with a trigger collider
    public int Damage = 1;
    public float PushForce = 2f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerHealth>().Invincible)
            {
                collision.GetComponent<PlayerHealth>().CurrentHealth -= Damage;
                Vector2 PushDirection = (collision.gameObject.transform.position - transform.position).normalized;
                collision.GetComponent<Rigidbody2D>().AddForce(PushForce * PushDirection, ForceMode2D.Impulse);
                //Debug.Log("Push");
            }
            
        }
    }

}
