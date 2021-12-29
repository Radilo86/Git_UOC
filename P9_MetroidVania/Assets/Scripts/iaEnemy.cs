using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iaEnemy : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    Transform player;

    [SerializeField]
    float rangoAgro; // A cuanta distancia el enemigo ve al jugador
    public float velocidadMov;
    private bool miraDerecha;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        miraDerecha = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distancia hasta el jugador
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: " + distJugador);

        if (distJugador < rangoAgro && Mathf.Abs(distJugador) > 1)
        {
            PerseguirJugador(); //Funcion de perseguir
            anim.SetFloat("Velocidad", 1);
            anim.SetBool("Atacar", false);
        }
        else if (Mathf.Abs(distJugador) < 1)
        {
            anim.SetBool("Atacar", true);
        }
        else
        {
            NoPerseguir();
            anim.SetFloat("Velocidad", 0);
        }
    }

    private void NoPerseguir()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void PerseguirJugador()
    {
        //Si estamos a la izquierda del jugador entonces movemos el enemigo hacia la derecha
        if (transform.position.x < player.position.x && !miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov, 0f);
            Flip();
        }
        else if (transform.position.x > player.position.x && miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
            Flip();
        }
        else if (!miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
        }
        else if (miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov, 0f);
        }
    }

    private void Flip()
    {
        // Defino nuevamente hacia donde esta mirando el jugador
        miraDerecha = !miraDerecha;

        // Multiplicar la escala en X del personaje por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }
}