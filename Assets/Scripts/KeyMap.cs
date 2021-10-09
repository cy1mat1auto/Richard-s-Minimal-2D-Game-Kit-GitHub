using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMap
{
    //You may reassign keys in this script to remap them in other linked scripts;
    //You may also add more reassignable keys to this script based on your needs;
    public static KeyCode Up = KeyCode.W, 
        Down = KeyCode.S, 
        Left = KeyCode.A, 
        Right = KeyCode.D, 
        Attack = KeyCode.Mouse0, 
        Cast = KeyCode.Q, 
        Interact = KeyCode.E,
        Menu = KeyCode.Tab, 
        Slot1 = KeyCode.Alpha1, 
        Slot2 = KeyCode.Alpha2, 
        Slot3 = KeyCode.Alpha3, 
        Slot4 = KeyCode.Alpha4,
        Special1, Special2, Special3;
}

