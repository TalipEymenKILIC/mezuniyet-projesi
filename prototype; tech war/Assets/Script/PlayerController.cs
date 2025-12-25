using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpspeed = 6f;
    private bool isGrounded = true;
    public float movespeed = 8f;
    Rigidbody2D rb;

    public float attackRange = 1f; // saldırı menzili
    public Transform attackPoint;  // kılıcın ucu
    public LayerMask enemyLayers;  // hangi katmanlardaki düşmanlara saldırılacak

   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    void Update()
    {
        

if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            isGrounded = false;
           


        }

    }

    void FixedUpdate()
    {
        float moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * movespeed, rb.velocity.y);

        


    }
    
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

}
