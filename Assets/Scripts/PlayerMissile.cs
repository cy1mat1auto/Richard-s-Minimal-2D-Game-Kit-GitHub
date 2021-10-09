using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public Vector2 Speed = new Vector2 (0, 20f);
    public int Damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponentInParent<EnemyHealth>().CurrentHealth -= Damage;
        }

        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
