using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princesa : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("abc"))
        {

            SceneManager.LoadScene(0);
            Debug.Log("Has compeltado el nivel");
        }
    }
}
