using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals ("bullet"))
        {
            Score.scoreValue += 10;
            Destroy(gameObject);
        }
    }
}
