using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 movement;
    
    public delegate void KillHandler();
    public static event KillHandler onKill; 
    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = ang;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            onKill();
        }
    }
}
