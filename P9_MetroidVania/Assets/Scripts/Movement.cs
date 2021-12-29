using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private BoxCollider2D Collider2D;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    { 
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))

        {
            Grounded = true;
        }

        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        { 
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    
}
    public void Attack()
    {
        Animator.Play("heroAttack");
        Collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }
    private void DisableAttack()
    {
        Collider2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

}
