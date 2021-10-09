using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //This script is attached to the health bar in the HUD in order to display the player's current health
    public PlayerHealth PH;
    public Slider HBar;
    // Start is called before the first frame update
    void Start()
    {
        if (PH == null)
        {
            PH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        if (HBar == null)
        {
            HBar = GetComponent<Slider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HBar.value = PH.CurrentHealth;
    }
}
