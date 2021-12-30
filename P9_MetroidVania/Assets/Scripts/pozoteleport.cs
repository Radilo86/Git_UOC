using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pozoteleport : MonoBehaviour
{

    public Text text;
    public int levelName;
    private bool inDoor = false;
    public int puntuacion = 0;
    public string level = "level";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()

    {
        TouchMove();
        /*if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelName);
        }*/
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((mousePos.x > 1) && inDoor)
            {
                /*
                // Insercion puntos al xml
                puntuacion += 250;
                ItemContainer.Save("items.xml", level, puntuacion.ToString());
                */
                SceneManager.LoadScene(levelName);
            }
            if (mousePos.x < -1)
            {
                //Debug.Log("NOTHING");
            }
        }
    }

}
