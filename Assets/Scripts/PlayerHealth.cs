using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //This script keeps track of player's health, and handles things like iframes and stun after receiving damage.
    public MvmtTopDn Mvmt;
    public int MaxHealth = 6, CurrentHealth = 6;
    private int HealthLastUpdate;
    private float DamageTime, StunTime;
    public bool Invincible = false;
    public float iTime = 0.5f, sTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (Mvmt == null)
        {
            Mvmt = GetComponent<MvmtTopDn>();
        }

        Invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth > 0)
        {
            if (CurrentHealth < HealthLastUpdate)
            {
                DamageTime = Time.time;
                StunTime = Time.time;
                Invincible = true;
                Mvmt.Stunned = true;
            }

            else
            {
                if (!Invincible)
                {

                }

                else
                {
                    if (Time.time - DamageTime > iTime)
                    {
                        Invincible = false;
                    }

                    if (Time.time - StunTime > sTime)
                    {
                        Mvmt.Stunned = false;
                    }
                }
            }
        }

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        HealthLastUpdate = CurrentHealth;
    }
}
