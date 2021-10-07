using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPost : MonoBehaviour
{
    //This script moves the terrain sprite to the sorting layer above or below the player depending on where the player
    //is standing. Is this a suitable solution?
    public SpriteRenderer SR;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (SR == null)
        {
            SR = GetComponent<SpriteRenderer>();
        }

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y > transform.position.y)
        {
            SR.sortingLayerName = "Ground2";
        }

        else
        {
            SR.sortingLayerName = "Ground1";
        }
    }
}
