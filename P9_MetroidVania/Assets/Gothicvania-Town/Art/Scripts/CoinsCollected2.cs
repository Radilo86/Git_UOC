using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("abc"))
        {
            /* Cuando recogemos la manzana ponemos SpriteRenderer en false
             * lo cual oculta el gameObject al pasar con el personaje por
             * encima
             */
            GetComponent<SpriteRenderer>().enabled = false;
            /* Habilitamos el efecto de sonido que tenemos por defecto en PlayOnAwake */
            GetComponent<AudioSource>().enabled = true;
            /* Seleccionamos el primer gameObject hijo al que esta asignado el Script
             * (esta asignado a apple y su primer hijo en la posicion 0 es el 
             * GameObject collected), lo marcamos como activo para que se ejecute
             */
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            /* Llamamos al metodo del script CoinsManager */
            FindObjectOfType<CoinsManager>().AllCoinsCollected();

            // Llamamos al metodo puntuacion al recoger una fruta y le damos 50 puntos por fruta
            FindObjectOfType<CoinsManager>().puntuacionMonedas(50);

            /* Por ultimo destruimos el objeto Apple y todos sus hijos
             * en un tiempo de 0.5 segundos
             */
            Destroy(gameObject, 0.5f);
        }
    }
}
