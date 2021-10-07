using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Use this script to make your camera follow your player; Tag your player gameobject as "Player" in the editor
    //before you begin. 
    public GameObject Player;
    public bool Following = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Can you think of a situation where we wouldn't want the camera to follow the player?
        if (Following)
        {
            //This code keeps the player perfectly centered in the camera view; is this how you want your camera to work?
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }
}
