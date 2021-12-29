using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    // Hacemos referencia al gameObject TransitionAnimation
    public GameObject transition;
    // Hacemos referencia al texto numerico de la UI
    public Text puntos;
    public int puntuacion = 0;

    public void AllCoinsCollected()
    {
        /* preguntamos si queda 1 hijo en el gameObject Coins
         * porque pasaremos el metodo en CoinsCollected justo antes
         * de destruir el objeto (si lo hacemos despues no hace nada)
         * por lo que el juego ha de terminar cuando detectemos que queda
         * una fruta que sera destruida en el paso siguiente
         */
        if (transform.childCount == 1)
        {
            Debug.Log("No quedan Monedas, has ganado");
            transition.SetActive(true);
            // Invocamos al metodo de cambio de escena y le damos un tiempo para realizarlo (2 segundos).
            Invoke("ChangeScene", 2);
        }
    }
    /* Con este metodo sumamos los puntos de las monedas recogidas y lo mostramos en el UI.
     * Esto pasara cada vez que se coja una moneda, ya que este metodo es llamado desde el 
     * sript CoinsCollected.cs
     */
    public void puntuacionMonedas(int num)
    {
        puntuacion = puntuacion + num;
        //Debug.Log(puntuacion);
        puntos.text = puntuacion.ToString();
    }

    void ChangeScene()
    {
        // Vamos al menu principal
        SceneManager.LoadScene(0);
        // Cargamos la escena actual
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
