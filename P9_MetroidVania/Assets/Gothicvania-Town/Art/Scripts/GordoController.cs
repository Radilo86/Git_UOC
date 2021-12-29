using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GordoController : MonoBehaviour
{
    public float speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    //private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    // Estas 3 variables nos serviran para controlar el salto segun la presion ejercida en el boton.
    public bool betterJump = false; // Nos va a permitir activar o desactivar este tipo de salto.
    public float fallMultiplier = 0.5f; // Estas 2 variables lo que van a hacer es que caiga mas rapido o lento
    public float lowJumpMultiplier = 1f; // Dando sensación de caida tipo Mario Bros.

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //  Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        /*Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("grounded", Grounded);
        if (Grounded)
        {
            Animator.SetBool("Jump", false);
        }
        else
        {
            Animator.SetBool("Jump", true);
        }
        */
        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        //  Attack();
    }
    /*metodo de ataque*/
    /*private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animator.SetBool("Attack", true);
        }
        else
        {
            Animator.SetBool("Attack", false);
        }
    }*/
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);

        /* Vamos a modificar la fuerza de la gravedad que afectara a la capacidad de salto
        * de nuestro personaje principal
        */
        // Comprobamos si la variable bool betterJump esta activada
        if (betterJump) // Si es true ejecutara lo que hay dentro
        {
            if (Rigidbody2D.velocity.y < 0)
            {
                /* Vector2.up es similar a indicar al vector la posicion (0,1), lo multiplicamos por
                 * la gravedad en el eje y (Physics.gravity.y) y por nuestro Multiplicador de velocidad
                 * por ultimo Time.deltaTime lo que hace es impedir que haya inconsistencia en los frames por segundo.
                 */
                Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            // Hay que poner la condicion de que no estemos pulsando space para evitar fallo, porque no podemos estar cuando es mayor de 0 pulsando el espacio
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetKey("space"))
            {
                GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }
    }
}
