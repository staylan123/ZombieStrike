using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlockScript : MonoBehaviour
{
    public delegate void KillHandler();
    public static event KillHandler onKill; 

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            onKill();
        }
    }
}
