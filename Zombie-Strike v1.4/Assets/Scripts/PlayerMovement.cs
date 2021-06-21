using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player Movement Speed
    
    public Rigidbody2D rb; // Rigid body ref
    public Camera cam; // Camera ref
    
    public GameManager gameManager;

    Vector2 movement;
    Vector2 mousePos;


    // Update is called once per frame
     void Awake(){
        rb = GetComponent<Rigidbody2D>();
       
        KillBlockScript.onKill += OnDeath;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Control for Horizontal Movement
        movement.y = Input.GetAxisRaw("Vertical"); // Control for Vertical Movement

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Transforms Player Movement

        Vector2 lookDirect = mousePos - rb.position;
        float ang = Mathf.Atan2(lookDirect.y, lookDirect.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = ang;
    }
  void OnCollisionEnter2D(Collision2D coll)
    {
      if(coll.gameObject.tag == "zombie")
        {
            gameManager.GameOver();
        }
    }
 void OnDeath()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnDestroy()
    {
        KillBlockScript.onKill -= OnDeath;
    }
}
