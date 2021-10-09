using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    //This enemy will simply patrol a path and fire missiles at the player; since this script is getting too big,
    //Enemy01Death.cs will handle the death behavior of this enemy.
    public Rigidbody2D rb;
    public GameObject Missile;
    public GameObject Player;
    public bool alerted = false, loop = false; //Looped paths don't work in this version of the script.
    public float alertRange = 7f;
    private bool retrace;
    public List<Vector2> PatrolPoints = new List<Vector2>();
    private Vector2 NextPoint, LastPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        //When the game begins, the enemy should spawn on the first point of its path; if no path is defined in the 
        //editor, stand on one spot:
        if (PatrolPoints.Count == 0)
        {
            PatrolPoints.Add(transform.position);
        }

        transform.position = PatrolPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!loop)
        {
            if (!retrace)
            {
                for (int i = 0; i < PatrolPoints.Count; i++)
                {
                    if (Vector2.Distance(transform.position, PatrolPoints[i]) < 0.01f)
                    {

                        LastPoint = PatrolPoints[i];

                        if (i == PatrolPoints.Count - 1)
                        {
                                retrace = true;
                                NextPoint = PatrolPoints[i - 1];
                        }

                        else
                        {
                            NextPoint = PatrolPoints[i + 1];
                        }
                    }
                }
            }

            else
            {
                for (int i = PatrolPoints.Count - 1; i >= 0; i--)
                {
                    if (Vector2.Distance(transform.position, PatrolPoints[i]) < 0.01f)
                    {
                        LastPoint = PatrolPoints[i];

                        if (i == 0)
                        {
                            NextPoint = PatrolPoints[i + 1];
                            retrace = false;
                        }

                        else
                        {
                            NextPoint = PatrolPoints[i - 1];
                        }

                    }
                }
            }
        }
        
        //Don't use this; the current code doesn't work:
        else
        {
            PatrolLoop();
        }
       
        //This determines if the enemy is alerted:
        if (Vector2.Distance(transform.position, Player.transform.position) < alertRange)
        {
            if (!alerted)
            {
                alerted = true;
                //Due to how fire rate is controlled, it is VERY important that InvokeRepeating() is triggered only once
                //when the enemy first becomes alerted:
                InvokeRepeating("Fire", 1, 2);
            }
            
        }

        else
        {
            //There is something very lazy about the next 2 lines; what's wrong with it?
            CancelInvoke("Fire");
            alerted = false;
        }

        if (alerted)
        {
            //Additional "alerted" behaviors like chasing after the player can go here;
        }

        rb.velocity = (NextPoint - LastPoint).normalized * 2f;
        
    }

    void PatrolLoop()
    {
        if (!retrace)
        {
            for (int i = 0; i < PatrolPoints.Count; i++)
            {
                /*if (NextPoint == PatrolPoints[0])
                {
                    Debug.Log("restoring loop");
                    Debug.Log(NextPoint);
                    if (Vector2.Distance(transform.position, NextPoint) < 0.05f)
                    {
                        LastPoint = NextPoint;
                        NextPoint = PatrolPoints[1];
                        Debug.Log("Loop Restored");
                    }
                }*/

                if (Vector2.Distance(transform.position, PatrolPoints[i]) < 0.01f)
                {

                    LastPoint = PatrolPoints[i];
                    Debug.Log(LastPoint);

                    if (i == PatrolPoints.Count - 1)
                    {

                        NextPoint = PatrolPoints[0];
                        Invoke("DelayLoop", 2f);
                        Debug.Log("Loop Finished");
                        //return;

                    }

                    else
                    {
                        NextPoint = PatrolPoints[i + 1];
                    }
                }
            }
        }

        else
        {
            for (int i = 0; i < PatrolPoints.Count; i++)
            {
                if (NextPoint == PatrolPoints[0])
                {
                    Debug.Log("restoring loop");
                    //Debug.Log(NextPoint);
                    if (Vector2.Distance(transform.position, NextPoint) < 0.05f)
                    {
                        LastPoint = NextPoint;
                        NextPoint = PatrolPoints[1];
                    }
                }

                else if (Vector2.Distance(transform.position, NextPoint) < 0.05f)
                {
                    LastPoint = PatrolPoints[i];

                    if (i == PatrolPoints.Count - 1)
                    {
                        Debug.Log("Loop Finished Again");
                        NextPoint = PatrolPoints[0];
                        //retrace = false;
                        Debug.Log("Loop Finished again");
                        //return;

                    }

                    else
                    {
                        NextPoint = PatrolPoints[i + 1];
                        Debug.Log(i);
                        Debug.Log(NextPoint);
                    }
                }
            }
        }
        
    }
    
    void DelayLoop()
    {
        retrace = true;
    }

    void Fire()
    {
        GameObject Proj = Instantiate(Missile as GameObject, transform.position, transform.rotation);
        Vector3 LookDir = Player.transform.position - transform.position;
        Proj.transform.Rotate(new Vector3(0, 0, Vector3.SignedAngle(-Proj.transform.up, Proj.transform.position - Player.transform.position, Vector3.forward)));
        Proj.GetComponent<Rigidbody2D>().velocity = Proj.transform.rotation.normalized * Proj.GetComponent<EnemyMissile>().Speed;
    }
}
