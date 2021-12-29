using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    // Necesitamos una referencia para nuestra animacion del tipo Animator
    public Animator animator;

    // Creamos un array de tipo GameObject para introducir las vidas de manera conjunta y no independiente
    public GameObject[] Vidas;
    private int life;

    private void Start()
    {
        // Inicializamos las vidas al tamaño de nuestro array de corazones
        life = Vidas.Length;
    }

    private void CheckLife()
    {
        // CONTROL DE VIDAS
        // Si nuestra vida es menor de 1, estamos muertos
        if (life < 1)
        {
            // Ejecutamos la animacion de morir
            // animator.Play("Dead");
            animator.Play("explotemonk");

            // Destruimos la ultima vida
            Destroy(Vidas[0].gameObject);

            // LLamamos al script que nos hace esperar un segundo
            // StartCoroutine(Esperar());

            // Cargamos la Scene que corresponda, por ejemplo Fin de Juego
            Invoke("SceneFin", 1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // Debug
            // Debug.Log("Has muerto");
        }
        // Si nuestra vida es menor de 2 y no es menor de 1, tenemos 1 vida.
        else if (life < 2)
        {
            // Ejecutamos la animacion de herido
            animator.Play("hitmonk");

            Destroy(Vidas[1].gameObject);
        }
        // Si nuestra vida es menor de 3 y no se cumplen los anteriores, tenemos 2 vidas
        else if (life < 3)
        {
            // Ejecutamos la animacion de herido
            animator.Play("hitmonk");

            // Podemos destruirlos o desactivarlos, vamos a optar por destruir.
            Destroy(Vidas[2].gameObject);
        }
        // Si no se cumple ninguno de los anteriores tenemos 3 vidas.
    }

    public void SceneFin()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDamaged()
    {
        /* Cuando nuestro personaje es golpeado, le restamos una vida
         * y llamamos al metodo CheckLife para que compruebe cuantas
         * vidas tenemos y las actualice en el UI
         */
        // restamos 1 a nuestra vida
        life--;
        CheckLife();
    }

    /*
    public IEnumerator Esperar()
    {
        // Esperamos un segundo antes de pasar a la siguiente accion.
        yield return new WaitForSeconds(3.0f);
    }
    */
}
