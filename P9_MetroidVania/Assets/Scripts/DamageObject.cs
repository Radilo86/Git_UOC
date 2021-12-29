using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    // Comprobamos si colisiona el jugador con los "pinchos" mediante el Tag
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("abc"))
        {
            // Debug.Log("Player Damage");
            // Destruimos el gameObject que colisiona, en este caso el jugador
            // Destroy(collision.gameObject);

            /* Vamos a llamar al metodo del script PlayerRespawn.cs 
             * que es el que gestiona la vida y modifica el hud 
             * del jugador.
             */
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
