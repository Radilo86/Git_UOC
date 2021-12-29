using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    enemy2 enemy2;
    public GameObject deathEffect;
    private void Start()
    {
        enemy2 = GetComponent<enemy2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon"))
        {
            enemy2.healthpoints -= 2f;
            if (enemy2.healthpoints <= 0)
            {
     
                Destroy(gameObject);
            }
        }
    }

}
