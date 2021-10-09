using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AimMarker;
    public GameObject Missile;
    // Start is called before the first frame update
    void Start()
    {
        if (AimMarker == null)
        {
            Debug.Log("AimMarker not assigned");
        }

        AimMarker.SetActive(false);
        //We won't autoassign this one;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyMap.Attack))
        {
            if (!AimMarker.activeSelf)
            {
                AimMarker.SetActive(true);
            }
        }

        //Upon release of your Attack key, missile fires and aim marker goes away:
        if (Input.GetKeyUp(KeyMap.Attack))
        {
            GameObject NewMissile = Instantiate(Missile as GameObject, transform.position, AimMarker.transform.rotation);
            NewMissile.GetComponent<Rigidbody2D>().velocity = NewMissile.transform.rotation.normalized * NewMissile.GetComponent<PlayerMissile>().Speed;
            if (AimMarker.activeSelf)
            {
                AimMarker.SetActive(false);
            }
        }
    }
}
