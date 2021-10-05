using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvmtTopDn : MonoBehaviour
{
    //Basic movement script for top-down/isometric 2D games; Attach this script to the player character.
    //This script supports key remapping through the KeyMap.cs Script; This is a useful practice when you're 
    //building larger projects that may benefit from user customization.
    public Rigidbody2D rb;
    public Vector2 AvgDirection;
    private float Sources;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyMap.Up))
        {
            AvgDirection = AvgDirection*Sources - Vector2.up;
            Sources -= 1;
            if (Sources != 0)
            {
                AvgDirection = AvgDirection / Sources;
            }

            else
            {
                AvgDirection = Vector2.zero;
            }
            rb.velocity = Speed * AvgDirection;
            Debug.Log(AvgDirection);
        }

        if (Input.GetKeyUp(KeyMap.Down))
        {
            AvgDirection = AvgDirection*Sources - Vector2.down;
            Sources -= 1;
            if (Sources != 0)
            {
                AvgDirection = AvgDirection / Sources;
            }

            else
            {
                AvgDirection = Vector2.zero;
            }
            rb.velocity = Speed * AvgDirection;
        }

        if (Input.GetKeyUp(KeyMap.Left))
        {
            AvgDirection = AvgDirection * Sources - Vector2.left;
            Sources -= 1;
            if (Sources != 0)
            {
                AvgDirection = AvgDirection / Sources;
            }

            else
            {
                AvgDirection = Vector2.zero;
            }
            rb.velocity = Speed * AvgDirection;
        }

        if (Input.GetKeyUp(KeyMap.Right))
        {
            AvgDirection = AvgDirection * Sources - Vector2.right;
            Sources -= 1;
            if (Sources != 0)
            {
                AvgDirection = AvgDirection / Sources;
            }

            else
            {
                AvgDirection = Vector2.zero;
            }
            rb.velocity = Speed * AvgDirection;
        }

    }

    private void FixedUpdate()
    {
        AvgDirection = Vector2.zero;
        Sources = 0f;
        if (Input.GetKey(KeyMap.Up))
        {
            AvgDirection += Vector2.up;
            Sources += 1;
        }

        if (Input.GetKey(KeyMap.Down))
        {
            AvgDirection += Vector2.down;
            Sources += 1;
        }

        if (Input.GetKey(KeyMap.Left))
        {
            AvgDirection += Vector2.left;
            Sources += 1;
        }

        if (Input.GetKey(KeyMap.Right))
        {
            AvgDirection += Vector2.right;
            Sources += 1;
        }

        if (Sources != 0)
        {
            AvgDirection = AvgDirection / Sources;
        }
        
        else
        {
            AvgDirection = Vector2.zero;
        }

        rb.velocity = Speed * AvgDirection;
    }
}
