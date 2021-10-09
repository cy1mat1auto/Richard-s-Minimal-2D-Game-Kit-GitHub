using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Death : MonoBehaviour
{
    //This is an ad-hoc script for handling the death behavior of the example enemy
    public EnemyHealth EH;
    public Enemy01 E1;
    public Collider2D col;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (EH == null)
        {
            EH = GetComponent<EnemyHealth>();
        }

        if (E1 == null)
        {
            E1 = GetComponent<Enemy01>();
        }

        if (col == null)
        {
            col = GetComponent<Collider2D>();
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //When the enemy's health reaches zero:
        if (EH.CurrentHealth == 0)
        {
            //This makes sure the enemy stops firing:
            E1.CancelInvoke();
            //This makes sure the enemy stops patrolling and detecting the player:
            E1.enabled = false;
            //This disables the enemy's main collider:
            col.enabled = false;
            //This makes sure the enemy stops moving:
            rb.velocity = Vector2.zero;
        }
    }
}
