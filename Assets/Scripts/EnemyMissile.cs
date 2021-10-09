using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    //Basic behavior for the enemy's missile
    public Vector2 Speed = new Vector2(0, 10);
    public int Damage = 1;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerHealth>().Invincible)
            {
                collision.GetComponent<PlayerHealth>().CurrentHealth -= Damage;
            }
        }

        if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
