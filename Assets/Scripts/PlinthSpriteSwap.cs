using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinthSpriteSwap : MonoBehaviour
{
    public GameObject Player;
    public Animator NewAnim;
    public Animator HolderAnim;
    public Sprite NewSprite;
    public bool Ready = false;
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
        if (Ready)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<SpriteRenderer>().sprite = NewSprite;
                HolderAnim.runtimeAnimatorController = Player.GetComponent<Animator>().runtimeAnimatorController;
                Player.GetComponent<Animator>().runtimeAnimatorController = NewAnim.runtimeAnimatorController;
                NewAnim.runtimeAnimatorController = HolderAnim.runtimeAnimatorController;
                Debug.Log("Player has swapped sprites");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            if (!Ready)
            {
                Ready = true;
            }

            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            if (Ready)
            {
                Ready = false;
            }
        }
    }
}
