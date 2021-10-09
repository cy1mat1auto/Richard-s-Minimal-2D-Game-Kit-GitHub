using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //This is a script dedicated to respawning the player
    public PlayerHealth PH;
    public Vector3 SpawnSpot;
    // Start is called before the first frame update
    void Start()
    {
        if (PH == null)
        {
            PH = GetComponent<PlayerHealth>();
        }

        SpawnSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //In this simplest version of the script, dying immediately moves the player to the starting position and
        //restores health to full. How would you rewrite this to suit your own needs?
        if (PH.CurrentHealth == 0)
        {
            transform.position = SpawnSpot;
            PH.CurrentHealth = PH.MaxHealth;
        }
    }
}
