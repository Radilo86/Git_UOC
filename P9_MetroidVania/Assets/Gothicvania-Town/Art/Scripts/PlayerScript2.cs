using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{

    public float runSpeed = 2.0f;
    public float jumpSpeed = 3.0f;
    bool movimiento;

    private Animator animacion;

    Rigidbody2D rb2D;

    // Estas 3 variables nos serviran para controlar el salto segun la presion ejercida en el boton.
    public bool betterJump = false; // Nos va a permitir activar o desactivar este tipo de salto.
    public float fallMultiplier = 0.5f; // Estas 2 variables lo que van a hacer es que caiga mas rapido o lento
    public float lowJumpMultiplier = 1f; // Dando sensación de caida tipo Mario Bros.

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }


    private void Update()
    {
        animacion.SetBool("walking", rb2D.velocity.x != 0.0f);
    }

    private void FixedUpdate()
    {
        /* 
         * Debug.Log(rb2D.velocity.x);
         * Debug.Log(rb2D.velocity.y);
        */

        // Comprobamos si pulsamos la tecla de o flecha derecha
        if ((Input.GetKey("d") || Input.GetKey("right")))
        {
            // utilizamos un vector de 2 dimensiones con eje x e y, donde x es runSpeed e y es rb2D.velocity.y
            // Con esto nos movemos en el eje positivo de la x e y.
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        // Comprobamos si pulsamos la tecla a o flecha izquierda
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            // Es exactamente igual para ir a la izquierda, solo que el eje x tendra signo negativo
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            // Si no pulsamos nada, estará quieto
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        // Si pulsamos la tecla espacio y estamos en el suelo ejecutara el codigo siguiente
        if (Input.GetKey("space"))
        {
            // Para saltar, ahora debemos desplazarnos en el eje Y
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        /* Vamos a modificar la fuerza de la gravedad que afectara a la capacidad de salto
       * de nuestro personaje principal
       */
        // Comprobamos si la variable bool betterJump esta activada
        if (betterJump) // Si es true ejecutara lo que hay dentro
        {
            // Tenemos la tecla de salto pulsada
            if (rb2D.velocity.y < 0 && Input.GetKey("space"))
            {
                /* Vector2.up es similar a indicar al vector la posicion (0,1), lo multiplicamos por
                 * la gravedad en el eje y (Physics.gravity.y) y por nuestro Multiplicador de velocidad
                 * por ultimo Time.deltaTime lo que hace es impedir que haya inconsistencia en los frames por segundo.
                 */
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            // Hay que poner la condicion de que no estemos pulsando space para evitar fallo, porque no podemos estar cuando es mayor de 0 pulsando el espacio
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetKey("space"))
            {
                GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }
    }
}