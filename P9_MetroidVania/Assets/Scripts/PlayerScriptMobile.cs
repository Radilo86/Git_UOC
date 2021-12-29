using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptMobile : MonoBehaviour
{
    public float speed = 0.8f;
    public float jumpSpeed;
    public Joystick joystick;
    Vector2 move;
    Rigidbody2D rb;
    private Animator animacion;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    float runSpeedHorizontal = 2f;
    float runSpeedVertical = 2f;

    // Estas 3 variables nos serviran para controlar el salto segun la presion ejercida en el boton.
    public bool betterJump = false; // Nos va a permitir activar o desactivar este tipo de salto.
    public float fallMultiplier = 0.5f; // Estas 2 variables lo que van a hacer es que caiga mas rapido o lento
    public float lowJumpMultiplier = 1f; // Dando sensación de caida tipo Mario Bros.

    private GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= .2f)
        {
            animacion.SetBool("walking", true);
            horizontalMove = speed;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            animacion.SetBool("walking", true);
            horizontalMove = -speed;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;
        }
        else
        {
            animacion.SetBool("walking", false);
            horizontalMove = 0f;
        }

        if(joystick.Vertical >= .2f && CheckGround.isGrounded)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        TouchMove();

        // Comprobamos si la variable bool betterJump esta activada
        if (betterJump) // Si es true ejecutara lo que hay dentro
        {
            // Tenemos la tecla de salto pulsada
            if (rb.velocity.y < 0 && joystick.Vertical >= .2f)
            {
                /* Vector2.up es similar a indicar al vector la posicion (0,1), lo multiplicamos por
                 * la gravedad en el eje y (Physics.gravity.y) y por nuestro Multiplicador de velocidad
                 * por ultimo Time.deltaTime lo que hace es impedir que haya inconsistencia en los frames por segundo.
                 */
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            // Hay que poner la condicion de que no estemos pulsando space para evitar fallo, porque no podemos estar cuando es mayor de 0 pulsando el espacio
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && joystick.Vertical <= .2f)
            {
                GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);      
    }

    void TouchMove()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.x > 1)
            {
                Debug.Log("ATTACK");
            }
            if(mousePos.x < -1)
            {
                Debug.Log("NOTHING");
            }
        }
    }
}
