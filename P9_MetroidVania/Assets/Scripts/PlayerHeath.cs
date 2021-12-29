using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (health> maxHealth)
        {
            health = maxHealth;
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            health -= collision.GetComponent<Enemy1>().damageToGive;
            health -= collision.GetComponent<enemy2>().damageToGive;
            health -= collision.GetComponent<GhostHalo>().damageToGive;
            if (health <= 0)
            {
                print("Game Over");
            }
        }
    }*/
}
