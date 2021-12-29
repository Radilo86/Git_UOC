using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    Enemy1 enemy;
    public GameObject deathEffect;

    private void Start()
    {
        enemy = GetComponent<Enemy1>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("weapon"))
        {
            enemy.healthpoints -= 2f;
            if (enemy.healthpoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}