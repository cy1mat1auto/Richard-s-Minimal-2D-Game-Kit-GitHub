using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //This is the script that controls the player's animations; The code will refer to the player's animator
    //AND variables from the MvmtTopDn.cs script which is used to control the player's movement.
    public Animator Anim;
    public MvmtTopDn MoveControls;
    // Start is called before the first frame update
    void Start()
    {
        if (Anim == null)
        {
            Anim = GetComponent<Animator>();
        }

        if (MoveControls == null)
        {
            MoveControls = GetComponent<MvmtTopDn>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveControls.Stunned)
        {
            if (MoveControls.AvgDirection.y > 0)
            {
                Anim.SetInteger("Walk", 1);
            }

            else if (MoveControls.AvgDirection.y < 0)
            {
                Anim.SetInteger("Walk", 3);
            }

            else
            {
                if (MoveControls.AvgDirection.x > 0)
                {
                    Anim.SetInteger("Walk", 2);
                }

                else if (MoveControls.AvgDirection.x < 0)
                {
                    Anim.SetInteger("Walk", 4);
                }

                else
                {
                    Anim.SetInteger("Walk", 0);
                }
            }
        }
    }
}
